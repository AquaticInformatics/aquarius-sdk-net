using System;
using System.Collections.Generic;

namespace Aquarius.TimeSeries.Client
{
    public class ConnectionPool
    {
        public static readonly ConnectionPool Instance = new ConnectionPool();

        private ConnectionPool()
        {
        }

        private readonly object _syncLock = new object();

        private readonly Dictionary<string, Connection> _connections = new Dictionary<string, Connection>();

        public Connection GetConnection(
            string hostname,
            string username,
            string password,
            Func<string, string, string> sessionTokenCreator,
            Action sessionDeleteAction)
        {
            var connectionKey = CreateConnectionKey(hostname, username, password);

            lock (_syncLock)
            {
                if (_connections.TryGetValue(connectionKey, out var connection))
                {
                    connection.IncrementConnectionCount();
                    return connection;
                }

                connection = new Connection(username, password, sessionTokenCreator, sessionDeleteAction);

                _connections.Add(connectionKey, connection);

                return connection;
            }
        }

        private static string CreateConnectionKey(string hostname, string username, string password)
        {
            return string.Join("/", hostname, username, password);
        }

        public void Reset()
        {
            lock (_syncLock)
            {
                _connections.Clear();
            }
        }
    }
}
