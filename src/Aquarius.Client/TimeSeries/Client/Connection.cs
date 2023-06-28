using System;
using System.Reflection;
using Aquarius.Helpers;
using ServiceStack.Logging;

namespace Aquarius.TimeSeries.Client
{
    public class Connection : IConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly bool TraceEnabled;

        private readonly object _syncLock = new object();

        static Connection()
        {
            TraceEnabled = AppSettings.Get("TraceConnectionPool", false);
        }

        public Connection(
            string hostname,
            string username,
            string password,
            IAuthenticator authenticator,
            Action<Connection> connectionRemovalAction)
        {
            Hostname = hostname;
            Username = username;
            Password = password;
            Authenticator = authenticator;
            ConnectionRemovalAction = connectionRemovalAction;

            ConnectionCount = 1;

            Trace("Created");

            CreateNewSession();
        }

        private void Trace(string message)
        {
            if (!TraceEnabled) return;

            Log.Info($"{GetHashCode()}: {Hostname}/{Username}/***: ConnectionCount={ConnectionCount} {message}");
        }

        private void CreateNewSession()
        {
            SessionToken = Authenticator.Login(Username, Password);

            Trace($"NewSession SessionToken={SessionToken}");
        }

        private void DeleteCurrentSession()
        {
            Trace($"Deleting SessionToken={SessionToken}");

            Authenticator.Logout();
            SessionToken = null;
        }

        public string SessionToken { get; private set; }

        public string Token() => SessionToken;


        private IAuthenticator Authenticator { get; }
        private Action<Connection> ConnectionRemovalAction { get; }
        private string Hostname { get; }
        private string Username { get; }
        private string Password { get; }

        internal int ConnectionCount { get; set; }

        public void ReAuthenticate()
        {
            lock (_syncLock)
            {
                CreateNewSession();
            }
        }

        public void ReAuthenticate(string token)
        {
            lock (_syncLock)
            {
                CreateNewSession();
            }
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
