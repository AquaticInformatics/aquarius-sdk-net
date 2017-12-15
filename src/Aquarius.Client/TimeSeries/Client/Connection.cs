using System;
using System.Diagnostics;

namespace Aquarius.TimeSeries.Client
{
    public class Connection
    {
        private readonly object _syncLock = new object();
        private readonly Stopwatch _idleTimer = Stopwatch.StartNew();

        public Connection(string username, string password, Func<string, string, string> sessionTokenCreator, Action sessionDeleteAction)
        {
            Username = username;
            Password = password;
            SessionTokenCreator = sessionTokenCreator;
            SessionDeleteAction = sessionDeleteAction;

            CreateNewSession();
            ConnectionCount = 1;
        }

        private void CreateNewSession()
        {
            SessionToken = SessionTokenCreator(Username, Password);
            RestartIdleTimer();
        }

        public string SessionToken { get; private set; }

        private Func<string, string, string> SessionTokenCreator { get; }
        private Action SessionDeleteAction { get; }
        private string Username { get; }
        private string Password { get; }

        internal int ConnectionCount { get; set; }

        public void ReconnectIfIdle(TimeSpan idleTimeSpan)
        {
            lock (_syncLock)
            {
                if (_idleTimer.Elapsed < idleTimeSpan)
                    return;

                SessionDeleteAction();
                CreateNewSession();
            }
        }

        public void RestartIdleTimer()
        {
            lock (_syncLock)
            {
                _idleTimer.Restart();
            }
        }

        public void Close()
        {
            lock (_syncLock)
            {
                if (ConnectionCount <= 0)
                    return;

                --ConnectionCount;

                if (ConnectionCount != 0)
                    return;

                SessionDeleteAction();
            }
        }

        public void IncrementConnectionCount()
        {
            lock (_syncLock)
            {
                ++ConnectionCount;
            }
        }
    }
}
