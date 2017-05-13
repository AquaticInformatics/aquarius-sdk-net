using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Aquarius.Helpers;
using Aquarius.TimeSeries.Client.EndPoints;
using Aquarius.TimeSeries.Client.Helpers;
using ServiceStack;
using ServiceStack.Logging;

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

        public IServiceClient PublishClient { get { return _serviceClients[ClientType.PublishJson]; } }
        public IServiceClient AcquisitionClient { get { return _serviceClients[ClientType.AcquisitionJson]; } }
        public IServiceClient ProvisioningClient { get { return _serviceClients[ClientType.ProvisioningJson]; } }

        public AquariusServerVersion ServerVersion { get; private set; }

        public IServiceClient RegisterCustomClient(string baseUri)
        {
            if (string.IsNullOrWhiteSpace(baseUri))
                throw new ArgumentOutOfRangeException(nameof(baseUri));

            ServiceClientBase client;
            if (_customClients.TryGetValue(baseUri, out client))
                return client;

            client = ClientHelper.CloneAuthenticatedClient(PublishClient as JsonServiceClient, baseUri);
            _customClients.Add(baseUri, client);

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
            var jsonClient = client as JsonServiceClient;

            if (jsonClient == null)
                throw new ArgumentException(@"Only JSON clients can be cloned", nameof(client));

            return ClientHelper.CloneAuthenticatedClient(jsonClient, new Uri(jsonClient.BaseUri).PathAndQuery);
        }

        public IServiceClient CloneAuthenticatedClientWithOverrideMethod(IServiceClient client, string overrideMethod)
        {
            var clone = (JsonServiceClient)CloneAuthenticatedClient(client);

            clone.RequestFilter = req => req.Headers[HttpHeaders.XHttpMethodOverride] = overrideMethod;

            return clone;
        }

        private string Username { get; set; }
        private string Password { get; set; }
        private string SessionToken { get; set; }
        private readonly Stopwatch _stopwatch;

        private enum ClientType
        {
            PublishJson,
            AcquisitionJson,
            ProvisioningJson,
        };

        private readonly Dictionary<ClientType, ServiceClientBase> _serviceClients = new Dictionary<ClientType, ServiceClientBase>();
        private readonly Dictionary<string, ServiceClientBase> _customClients = new Dictionary<string, ServiceClientBase>();

        private AquariusClient()
        {
            SetupServiceStack();

            _stopwatch = Stopwatch.StartNew();
            _stopwatch.Stop();
            _stopwatch.Reset();
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
            ReconnectIfIdle();

            return new ScopeAction(() => _stopwatch.Restart());
        }

        private void ReconnectIfIdle()
        {
            if (_stopwatch.Elapsed < IdleConnectionTimeSpan)
                return;

            DeleteSession();
            ConnectUsingSavedCredentials();
        }

        private void ConnectUsingSavedCredentials()
        {
            SessionToken = ClientHelper.Login(_serviceClients.First().Value, Username, Password);

            SetAuthenticationTokenForConnectedClients(_serviceClients);
            SetAuthenticationTokenForConnectedClients(_customClients);
        }

        private void SetAuthenticationTokenForConnectedClients<TKey>(Dictionary<TKey, ServiceClientBase> clientDictionary)
        {
            foreach (var client in clientDictionary.Values)
            {
                ClientHelper.SetAuthenticationToken(client, SessionToken);
            }
        }

        private void Connect(string hostname, string username, string password)
        {
            _serviceClients.Add(ClientType.PublishJson, new SdkServiceClient(PublishV2.ResolveEndpoint(hostname)));
            _serviceClients.Add(ClientType.AcquisitionJson, new SdkServiceClient(AcquisitionV2.ResolveEndpoint(hostname)));
            _serviceClients.Add(ClientType.ProvisioningJson, new SdkServiceClient(Provisioning.ResolveEndpoint(hostname)));

            Username = username;
            Password = password;

            ServerVersion = new AquariusSystemDetector().GetAquariusServerVersion(hostname);

            ConnectUsingSavedCredentials();
        }

        private void Disconnect()
        {
            DeleteSession();

            ClearConnectedClients(_serviceClients);
            ClearConnectedClients(_customClients);
        }

        private static void ClearConnectedClients<TKey>(Dictionary<TKey, ServiceClientBase> clientDictionary)
        {
            foreach (var client in clientDictionary.Values)
            {
                client.Dispose();
            }

            clientDictionary.Clear();
        }

        private void DeleteSession()
        {
            if (string.IsNullOrWhiteSpace(SessionToken))
                return;

            try
            {
                ClientHelper.Logout(_serviceClients.First().Value);
            }
            catch (Exception exception)
            {
                Log.Warn("Ignoring exception during disconnect", exception);
            }

            SessionToken = null;
        }
    }
}
