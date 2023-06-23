using System.Collections.Concurrent;
using System.Linq;

namespace Aquarius.TimeSeries.Client
{
    public class ConnectionPool
    {
        public static readonly ConnectionPool Instance = new ConnectionPool();

        private readonly object _syncLock = new object();

        private ConnectionPool()
        {
        }

        private readonly ConcurrentDictionary<string, IConnection> _connections = new ConcurrentDictionary<string, IConnection>();

        public Connection GetConnection(
            string hostname,
            string username,
            string password,
            IAuthenticator authenticator)
        {
            lock (_syncLock)
            {
                return _connections.AddOrUpdate(
                    CreateConnectionKey(hostname, username, password),
                    key => new Connection(hostname, username, password, authenticator, Remove),
                    (key, connection) =>
                    {
                        connection.IncrementConnectionCount();
                        return connection;
                    }) as Connection;
            }
        }

        public AccessTokenConnection GetConnection(
            string hostname,
            string accessToken,
            IAuthenticator authenticator)
        {
            var connectionKey = string.Join("/", hostname, accessToken);

            lock (_syncLock)
            {
                return _connections.AddOrUpdate(
                    connectionKey,
                    key => new AccessTokenConnection(hostname, accessToken, authenticator, Remove),
                    (key, connection) =>
                    {
                        connection.IncrementConnectionCount();
                        return connection;
                    }) as AccessTokenConnection;
            }
        }

        private static string CreateConnectionKey(string hostname, string username, string password)
        {
            return string.Join("/", hostname, username, password);
        }

        public void Reset()
        {
            // ReSharper disable once InconsistentlySynchronizedField
            _connections.Clear();
        }

        public void Cleanup()
        {
            // ReSharper disable once InconsistentlySynchronizedField
            foreach (var connection in _connections.Values)
            {
                connection.Close();
            }
        }

        private void Remove(IConnection connection)
        {
            var itemToRemove = _connections.FirstOrDefault(kvp => kvp.Value == connection);

            if (itemToRemove.Value != null)
            {
                _connections.TryRemove(itemToRemove.Key, out var _);
            }
        }
    }
}
