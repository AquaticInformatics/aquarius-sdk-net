using System;
using System.Collections.Generic;
using System.Linq;
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

        private static readonly object SyncLock = new object();

        private static bool _serviceStackConfigured;
        private static readonly TimeSpan IdleConnectionTimeSpan = TimeSpan.FromMinutes(10);

        private static void SetupServiceStack()
        {
            lock (SyncLock)
            {
                if (_serviceStackConfigured)
                    return;

                ServiceStackConfig.ConfigureServiceStack();

                _serviceStackConfigured = true;
            }
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

            client = ClientHelper.CloneAuthenticatedClient(PublishClient as JsonServiceClient, baseUri);
            CustomClients.Add(baseUri, client);

            return client;
        }

        public IEnumerable<TResponse> SendBatchRequests<TRequest, TResponse>(IServiceClient client, int batchSize, IEnumerable<TRequest> requests, CancellationToken? cancellationToken = null)
            where TRequest : IReturn<TResponse>
        {
            using (var batchClient = CreateBatchGetRequestClient(client))
            {
                return batchClient.SendAll<TRequest, TResponse>(batchSize, requests, cancellationToken);
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

            clone.RequestFilter = req => req.Headers[HttpHeaders.XHttpMethodOverride] = overrideMethod;

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
            Connection.ReconnectIfIdle(IdleConnectionTimeSpan);

            return new ScopeAction(() => Connection.RestartIdleTimer());
        }

        private void SetAuthenticationTokenForConnectedClients<TKey>(Dictionary<TKey, IServiceClient> clientDictionary)
        {
            foreach (var client in clientDictionary.Values.Cast<ServiceClientBase>())
            {
                if (client == null)
                    continue;

                ClientHelper.SetAuthenticationToken(client, Connection.SessionToken);
            }
        }

        private void Connect(string hostname, string username, string password)
        {
            ServiceClients.Add(ClientType.PublishJson, new SdkServiceClient(PublishV2.ResolveEndpoint(hostname)));
            ServiceClients.Add(ClientType.AcquisitionJson, new SdkServiceClient(AcquisitionV2.ResolveEndpoint(hostname)));
            ServiceClients.Add(ClientType.ProvisioningJson, new SdkServiceClient(ProvisioningV1.ResolveEndpoint(hostname)));

            ServerVersion = new AquariusSystemDetector().GetAquariusServerVersion(hostname);

            Connection = ConnectionPool.Instance.GetConnection(hostname, username, password, CreateSession, DeleteSession);
        }

        private void Disconnect()
        {
            Connection.Close();

            ClearConnectedClients(ServiceClients);
            ClearConnectedClients(CustomClients);
        }

        private static void ClearConnectedClients<TKey>(Dictionary<TKey, IServiceClient> clientDictionary)
        {
            foreach (var client in clientDictionary.Values)
            {
                client.Dispose();
            }

            clientDictionary.Clear();
        }

        internal string CreateSession(string username, string password)
        {
            var sessionToken = ClientHelper.Login(ServiceClients.First().Value, username, password);

            SetAuthenticationTokenForConnectedClients(ServiceClients);
            SetAuthenticationTokenForConnectedClients(CustomClients);

            return sessionToken;
        }

        internal void DeleteSession()
        {
            try
            {
                if (FirstNgVersion.IsLessThan(ServerVersion))
                {
                    ClientHelper.Logout(ServiceClients.First().Value);
                }
            }
            catch (Exception exception)
            {
                Log.Warn("Ignoring exception during disconnect", exception);
            }
        }

        private static readonly AquariusServerVersion FirstNgVersion = AquariusServerVersion.Create("14");
    }
}
