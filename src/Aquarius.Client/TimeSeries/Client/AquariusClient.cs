using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using Aquarius.Helpers;
using Aquarius.TimeSeries.Client.EndPoints;
using Aquarius.TimeSeries.Client.Helpers;
using ServiceStack;
using ServiceStack.Logging;
using ProvisioningV1 = Aquarius.TimeSeries.Client.EndPoints.Provisioning;

namespace Aquarius.TimeSeries.Client
{
    public class AquariusClient : IAquariusClient
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static IAquariusClient CreateConnectedClient(string hostname, string username, string password)
        {
            var client = new AquariusClient();

            client.Connect(hostname, username, password);

            return client;
        }

        public static IAquariusClient ClientFromExistingSession(string hostname, string existingSessionToken)
        {
            var client = new AquariusClient();

            client.Connect(hostname, existingSessionToken);

            return client;
        }

        private static readonly object SyncLock = new object();

        private static bool _serviceStackConfigured;

        private static void SetupServiceStack()
        {
            lock (SyncLock)
            {
                if (_serviceStackConfigured)
                    return;

                ServiceStackConfig.ConfigureServiceStack();

                EnableClientCleanupOnApplicationExit();

                _serviceStackConfigured = true;
            }
        }

        private static void EnableClientCleanupOnApplicationExit()
        {
            AppDomain.CurrentDomain.ProcessExit += CleanupConnectionPool;
        }

        private static void CleanupConnectionPool(object sender, EventArgs eventArgs)
        {
            ConnectionPool.Instance.Cleanup();
        }

        public IServiceClient Publish => ServiceClients[ClientType.PublishJson];
        public IServiceClient Acquisition => ServiceClients[ClientType.AcquisitionJson];
        public IServiceClient Provisioning => ServiceClients[ClientType.ProvisioningJson];
        public IServiceClient PublishClient => Publish;
        public IServiceClient AcquisitionClient => Acquisition;
        public IServiceClient ProvisioningClient => Provisioning;

        public AquariusServerVersion ServerVersion { get; internal set; }

        public IServiceClient RegisterCustomClient(string baseUri)
        {
            if (string.IsNullOrWhiteSpace(baseUri))
                throw new ArgumentOutOfRangeException(nameof(baseUri));

            if (CustomClients.TryGetValue(baseUri, out var client))
                return client;

            client = ClientHelper.CloneAuthenticatedClient(Publish as JsonServiceClient, baseUri);
            AddCustomClient(baseUri, client);

            return client;
        }

        public string GetBaseUri(IServiceClient client)
        {
            return BaseUris.TryGetValue(client, out var baseUri)
                ? baseUri
                : null;
        }

        public IEnumerable<TResponse> SendBatchRequests<TRequest, TResponse>(
            IServiceClient client,
            int batchSize,
            IEnumerable<TRequest> requests,
            CancellationToken? cancellationToken = null,
            IProgressReporter progressReporter = null)
            where TRequest : IReturn<TResponse>
        {
            using (var batchClient = CreateBatchGetRequestClient(client))
            {
                return batchClient.SendAll<TRequest, TResponse>(batchSize, requests, cancellationToken, progressReporter);
            }
        }

        private JsonServiceClient CreateBatchGetRequestClient(IServiceClient client)
        {
            return CloneAuthenticatedClientWithOverrideMethod(client, HttpMethods.Get) as JsonServiceClient;
        }

        public IServiceClient CloneAuthenticatedClient(IServiceClient client)
        {
            if (!(client is JsonServiceClient jsonClient))
                throw new ArgumentException(@"Only JSON clients can be cloned", nameof(client));

            return ClientHelper.CloneAuthenticatedClient(jsonClient, new Uri(jsonClient.BaseUri).PathAndQuery);
        }

        public IServiceClient CloneAuthenticatedClientWithOverrideMethod(IServiceClient client, string overrideMethod)
        {
            var clone = (JsonServiceClient)CloneAuthenticatedClient(client);

            clone.RequestFilter = req =>
            {
                // Keep calling any existing request filter
                ((JsonServiceClient) client)?.RequestFilter?.Invoke(req);

                req.Headers[HttpHeaders.XHttpMethodOverride] = overrideMethod;
            };

            return clone;
        }

        internal Connection Connection { get; set; }

        internal enum ClientType
        {
            PublishJson,
            AcquisitionJson,
            ProvisioningJson,
        };

        internal readonly Dictionary<ClientType, IServiceClient> ServiceClients = new Dictionary<ClientType, IServiceClient>();
        internal readonly Dictionary<string, IServiceClient> CustomClients = new Dictionary<string, IServiceClient>();
        private readonly Dictionary<IServiceClient,string> BaseUris = new Dictionary<IServiceClient, string>();

        internal void AddServiceClient(ClientType clientType, IServiceClient serviceClient, string baseUri)
        {
            ServiceClients.Add(clientType, serviceClient);
            AddBaseUri(serviceClient, baseUri);
        }

        internal void AddCustomClient(string baseUri, IServiceClient serviceClient)
        {
            CustomClients.Add(baseUri, serviceClient);
            AddBaseUri(serviceClient, baseUri);
        }

        private void AddBaseUri(IServiceClient serviceClient, string baseUri)
        {
            BaseUris[serviceClient] = baseUri;
        }

        private void AddServiceClient(ClientType clientType, string baseUri)
        {
            AddServiceClient(clientType, CreateClient(baseUri), baseUri);
        }

        internal AquariusClient()
        {
            SetupServiceStack();
        }

        public void Dispose()
        {
            lock (SyncLock)
            {
                Disconnect();
            }
        }

        public ScopeAction SessionKeepAlive()
        {
            // This is now a no-op
            return new ScopeAction(null);
        }

        private void Connect(string hostname, string username, string password)
        {
            InternalConnect(hostname, () => ConnectionPool.Instance.GetConnection(hostname, username, password, Authenticator.Create(hostname)));
        }

        private void Connect(string hostname, string existingSessionToken)
        {
            const string fakeUsername = "!BrowserUser!";
            const string fakePassword = "!BrowserPassword!";

            InternalConnect(hostname, () => ConnectionPool.Instance.GetConnection(hostname, fakeUsername, fakePassword, ExistingSessionAuthenticator.Create(existingSessionToken)));
        }

        private void InternalConnect(string hostname, Func<Connection> connectionFactory)
        {
            AddServiceClient(ClientType.PublishJson, PublishV2.ResolveEndpoint(hostname));
            AddServiceClient(ClientType.AcquisitionJson, AcquisitionV2.ResolveEndpoint(hostname));
            AddServiceClient(ClientType.ProvisioningJson, ProvisioningV1.ResolveEndpoint(hostname));

            ServerVersion = AquariusSystemDetector.Instance.GetAquariusServerVersion(hostname);

            Connection = connectionFactory();

            SetAutomaticReAuthentication();
        }

        private SdkServiceClient CreateClient(string baseUri)
        {
            return new SdkServiceClient(baseUri)
            {
                RequestFilter = CommonRequestFilter
            };
        }

        private void CommonRequestFilter(HttpWebRequest request)
        {
            if (string.IsNullOrEmpty(Connection.SessionToken))
            {
                request.Headers.Remove(AuthenticationHeaders.AuthenticationHeaderNameKey);
            }
            else
            {
                request.Headers[AuthenticationHeaders.AuthenticationHeaderNameKey] = Connection.SessionToken;
            }
        }

        private void SetAutomaticReAuthentication()
        {
            SetAutomaticReAuthenticationForConnectedClients(ServiceClients);
            SetAutomaticReAuthenticationForConnectedClients(CustomClients);
        }

        private void SetAutomaticReAuthenticationForConnectedClients<TKey>(Dictionary<TKey, IServiceClient> clientDictionary)
        {
            foreach (var client in clientDictionary.Values.Cast<ServiceClientBase>())
            {
                if (client == null)
                    continue;

                client.OnAuthenticationRequired = () => ReAuthenticate(client);
            }
        }

        private void ReAuthenticate(ServiceClientBase client)
        {
            var expiredToken = Connection.SessionToken;

            Connection.ReAuthenticate();

            Log.Info($"Re-authenticated with {client.BaseUri} (v{ServerVersion}). Replaced expiredToken={expiredToken} with newToken={Connection.SessionToken}");
        }

        private void Disconnect()
        {
            Connection.Close();

            ClearConnectedClients(ServiceClients);
            ClearConnectedClients(CustomClients);

            BaseUris.Clear();
        }

        private void ClearConnectedClients<TKey>(Dictionary<TKey, IServiceClient> clientDictionary)
        {
            foreach (var client in clientDictionary.Values)
            {
                client.Dispose();
                BaseUris.Remove(client);
            }

            clientDictionary.Clear();
        }
    }
}
