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
        : ConnectionTestBase<Connection, Authenticator>
    {

        protected override IAuthenticator CreateMockAuthenticator()
        {
            var mockAuthenticator = Substitute.For<IAuthenticator>();

            mockAuthenticator
                .Login(Arg.Any<string>(), Arg.Any<string>())
                .Returns(x => _fixture.Create<string>());

            return mockAuthenticator;
        }

        protected override Connection CreateMockConnection() => new Connection(
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _mockAuthenticator,
                RemoveConnection);

        protected override void AssertExpectedConnectionCount(int expectedCount) =>
            _connection.ConnectionCount.ShouldBeEquivalentTo(expectedCount, nameof(_connection.ConnectionCount));

        protected override void AssertExpectedSessionCreateCount(int expectedCount) =>
            _mockAuthenticator.Received(expectedCount).Login(Arg.Any<string>(), Arg.Any<string>());

        protected override void AssertExpectedSessionDeleteCount(int expectedCount) =>
            _mockAuthenticator.Received(expectedCount).Logout();

        protected override void AssertExpectedConnectionRemovalCount(int expectedCount)
        {
            _connectionRemovalCount.ShouldBeEquivalentTo(expectedCount, nameof(_connectionRemovalCount));
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
