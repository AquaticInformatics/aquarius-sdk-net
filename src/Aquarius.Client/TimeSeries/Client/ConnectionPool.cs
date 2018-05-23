using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Aquarius.TimeSeries.Client
{
    public class ConnectionPool
    {
        public static readonly ConnectionPool Instance = new ConnectionPool();

        private ConnectionPool()
        {
        }

        private readonly ConcurrentDictionary<string, Connection> _connections = new ConcurrentDictionary<string, Connection>();

        public Connection GetConnection(
            string hostname,
            string username,
            string password,
            Func<string, string, string> sessionTokenCreator,
            Action sessionDeleteAction)
        {
            return _connections.AddOrUpdate(
                CreateConnectionKey(hostname, username, password),
                key => new Connection(username, password, sessionTokenCreator, sessionDeleteAction, Remove),
                (key, connection) =>
                {
                    connection.IncrementConnectionCount();
                    return connection;
                });
        }

        private static string CreateConnectionKey(string hostname, string username, string password)
        {
            return string.Join("/", hostname, username, password);
        }

        public void Reset()
        {
            _connections.Clear();
        }

        public void Cleanup()
        {
            foreach (var connection in _connections.Values)
            {
                connection.Close();
            }
        }

        private void Remove(Connection connection)
        {
            var itemToRemove = _connections.FirstOrDefault(kvp => kvp.Value == connection);

            if (itemToRemove.Value != null)
            {
                _connections.TryRemove(itemToRemove.Key, out var _);
            }
        }
    }
}
