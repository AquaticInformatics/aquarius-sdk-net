using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Aquarius.Client.EndPoints;
using Aquarius.Client.Helpers;
using ServiceStack;
using ServiceStack.Logging;

namespace Aquarius.Client
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
        public IServiceClient ProcessorClient { get { return _serviceClients[ClientType.ProcessorJson]; } }
        public IServiceClient FieldDataClient { get { return _serviceClients[ClientType.FieldDataJson]; } }

        private string Username { get; set; }
        private string Password { get; set; }
        private string SessionToken { get; set; }
        private readonly Stopwatch _stopwatch;

        private enum ClientType
        {
            PublishJson,
            AcquisitionJson,
            ProvisioningJson,
            ProcessorJson,
            FieldDataJson,
        };

        private readonly Dictionary<ClientType, ServiceClientBase> _serviceClients = new Dictionary<ClientType, ServiceClientBase>();

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

            foreach (var client in _serviceClients.Values)
            {
                ClientHelper.SetAuthenticationToken(client, SessionToken);
            }
        }

        private void Connect(string hostname, string username, string password)
        {
            _serviceClients.Add(ClientType.PublishJson, new JsonServiceClient(PublishV2.ResolveEndpoint(hostname)));
            _serviceClients.Add(ClientType.AcquisitionJson, new JsonServiceClient(AcquisitionV2.ResolveEndpoint(hostname)));
            _serviceClients.Add(ClientType.ProvisioningJson, new JsonServiceClient(Provisioning.ResolveEndpoint(hostname)));
            _serviceClients.Add(ClientType.ProcessorJson, new JsonServiceClient(Processor.ResolveEndpoint(hostname)));
            _serviceClients.Add(ClientType.FieldDataJson, new JsonServiceClient(FieldData.ResolveEndpoint(hostname)));

            Username = username;
            Password = password;

            ConnectUsingSavedCredentials();
        }

        private void Disconnect()
        {
            DeleteSession();

            foreach (var client in _serviceClients.Values)
            {
                client.Dispose();
            }

            _serviceClients.Clear();
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
