using System;
using System.Reflection;
using Aquarius.Helpers;
using ServiceStack.Logging;

namespace Aquarius.TimeSeries.Client
{
    public class AccessTokenConnection : IConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly bool TraceEnabled;

        private readonly object _syncLock = new object();
        
        private IAuthenticator Authenticator { get; }
        private Action<AccessTokenConnection> ConnectionRemovalAction { get; }
        private string Hostname { get; }
        internal int ConnectionCount { get; set; }
        
        public string AccessToken { get; private set; }

        public string Token() => AccessToken;

        static AccessTokenConnection()
        {
            TraceEnabled = AppSettings.Get("TraceConnectionPool", false);
        }

        public AccessTokenConnection(
            string hostname,
            string accessToken,
            IAuthenticator authenticator,
            Action<AccessTokenConnection> connectionRemovalAction)
        {
            Hostname = hostname;
            AccessToken = accessToken;
            Authenticator = authenticator;
            ConnectionRemovalAction = connectionRemovalAction;
            ConnectionCount = 1;
            
            Trace("Created");
            
            CreateNewSession();
        }

        private void Trace(string message)
        {
            if (!TraceEnabled)
                return;
            
            Log.Info($"{GetHashCode()}: {Hostname}/{Token().Substring(0, 4)}/***: ConnectionCount={ConnectionCount} {message}");
        }
        
        private void CreateNewSession()
        {
            Authenticator.Login(AccessToken);

            Trace($"NewSession AccessToken={AccessToken}");
        }

        private void DeleteCurrentSession()
        {
            Trace($"Deleting AccessToken={AccessToken}");
            
            Authenticator.Logout();
            AccessToken = null;
        }

        public void ReAuthenticate()
        {
            throw new NotImplementedException(
                "Re-authentication not supported for access token-based authentication. Login to acquire a new access token.");
        }

        public void Close()
        {
            lock (_syncLock)
            {
                if (ConnectionCount <= 0)
                    return;

                --ConnectionCount;

                Trace("Decreased connection count.");

                if (ConnectionCount != 0)
                    return;
                
                DeleteCurrentSession();
                ConnectionRemovalAction(this);
                
                Trace("Closed");
            }
        }

        public void IncrementConnectionCount()
        {
            lock (_syncLock)
            {
                ++ConnectionCount;
                
                Trace("Increased connection count.");
            }
        }
    }
}