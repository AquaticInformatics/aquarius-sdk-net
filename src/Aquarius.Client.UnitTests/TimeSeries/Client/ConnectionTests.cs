using Aquarius.TimeSeries.Client;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.Client.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class ConnectionTests
    {
        private IFixture _fixture;
        private Connection _connection;
        private int _connectionRemovalCount;
        private IAuthenticator _mockAuthenticator;

        [SetUp]
        public void BeforeEachTest()
        {
            _fixture = new Fixture();
            _connectionRemovalCount = 0;

            _mockAuthenticator = CreateMockAuthenticator();

            _connection = new Connection(_fixture.Create<string>(), _fixture.Create<string>(), _fixture.Create<string>(), _mockAuthenticator, RemoveConnection);
        }

        private IAuthenticator CreateMockAuthenticator()
        {
            var mockAuthenticator = Substitute.For<IAuthenticator>();

            mockAuthenticator
                .Login(Arg.Any<string>(), Arg.Any<string>())
                .Returns(x => _fixture.Create<string>());

            return mockAuthenticator;
        }

        private void RemoveConnection(Connection connection)
        {
            ++_connectionRemovalCount;
        }

        [Test]
        public void NewlyConstructedConnection_TracksOneConnection()
        {
            AssertExpectedConnectionCount(1);
            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }

        private void AssertExpectedConnectionCount(int expectedCount)
        {
            _connection.ConnectionCount.ShouldBeEquivalentTo(expectedCount, nameof(_connection.ConnectionCount));
        }

        private void AssertExpectedSessionCreateCount(int expectedCount)
        {
            _mockAuthenticator.Received(expectedCount).Login(Arg.Any<string>(), Arg.Any<string>());
        }

        private void AssertExpectedSessionDeleteCount(int expectedCount)
        {
            _mockAuthenticator.Received(expectedCount).Logout();
        }

        private void AssertExpectedConnectionRemovalCount(int expectedCount)
        {
            _connectionRemovalCount.ShouldBeEquivalentTo(expectedCount, nameof(_connectionRemovalCount));
        }

        [Test]
        public void IncrementConnectionCount_IncrementsConnectionCount()
        {
            _connection.IncrementConnectionCount();

            AssertExpectedConnectionCount(2);
            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }

        [Test]
        public void Close_WithNonPositiveConnectionCount_DoesNotDeleteSession()
        {
            _connection.ConnectionCount = 0;

            _connection.Close();

            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }

        [Test]
        public void Close_WithSingleConnectCount_DeletesSession()
        {
            _connection.Close();

            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(1);
            AssertExpectedConnectionRemovalCount(1);
        }

        [Test]
        public void Close_WithMoreThanOneConnection_DoesNotDeleteSession()
        {
            _connection.ConnectionCount = 2;

            _connection.Close();

            AssertExpectedSessionCreateCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);
        }

        [Test]
        public void ReAuthenticate_CreatesNewSessionWithoutDeletingExistingSession()
        {
            var sessionToken = _connection.SessionToken;

            _connection.ReAuthenticate();

            AssertExpectedSessionCreateCount(2);
            AssertExpectedConnectionCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);

            sessionToken.Should().NotBe(_connection.SessionToken, "a new session token should be created");
        }
    }
}
