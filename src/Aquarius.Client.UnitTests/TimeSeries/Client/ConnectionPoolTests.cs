using Aquarius.TimeSeries.Client;
using FluentAssertions;
using NUnit.Framework;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class ConnectionPoolTests
    {
        private ConnectionPool _connectionPool;
        private IFixture _fixture;

        [SetUp]
        public void BeforeEachTest()
        {
            _fixture = new Fixture();

            _connectionPool = ConnectionPool.Instance;
            _connectionPool.Reset();
        }

        [Test]
        public void GetConnection_WithOneConnectionKey_CreatesASingleConnection()
        {
            var actual = GetConnection(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>());

            AssertConnectionCount(actual, 1);
        }

        private Connection GetConnection(string hostname, string username, string password)
        {
            return _connectionPool.GetConnection(hostname, username, password, CreateFakeSessionToken, DeleteSession);
        }

        private string CreateFakeSessionToken(string username, string password)
        {
            return $"Username={username} Password={password} Session={_fixture.Create<string>()}";
        }

        private void DeleteSession()
        {
        }

        private void AssertConnectionCount(Connection connection, int expectedCount)
        {
            connection.ConnectionCount.ShouldBeEquivalentTo(expectedCount);
        }

        [Test]
        public void GetConnection_WithTwoDifferentConnectionKeys_CreatesTwoConnections()
        {
            var actual1 = GetConnection(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>());
            var actual2 = GetConnection(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>());

            AssertConnectionCount(actual1, 1);
            AssertConnectionCount(actual2, 1);
        }

        [Test]
        public void GetConnection_WithTwoIdenticalConnectionKeys_CreatesOneConnection()
        {
            var hostname = _fixture.Create<string>();
            var username = _fixture.Create<string>();
            var password = _fixture.Create<string>();

            var actual1 = GetConnection(hostname, username, password);
            var actual2 = GetConnection(hostname, username, password);

            AssertConnectionCount(actual1, 2);
            AssertConnectionCount(actual2, 2);
            actual1.ShouldBeEquivalentTo(actual2);
        }

        [Test]
        public void GetConnection_TwoConsecutiveConnectionsToSameSystem_ConnectsTwice()
        {
            var hostname = _fixture.Create<string>();
            var username = _fixture.Create<string>();
            var password = _fixture.Create<string>();

            var actual1 = GetConnection(hostname, username, password);
            actual1.Close();

            var actual2 = GetConnection(hostname, username, password);
            actual2.Close();

            AssertConnectionCount(actual1, 0);
            AssertConnectionCount(actual2, 0);
            actual1.ShouldBeEquivalentTo(actual2, options =>
                options.Excluding(o => o.SessionToken));
        }
    }
}
