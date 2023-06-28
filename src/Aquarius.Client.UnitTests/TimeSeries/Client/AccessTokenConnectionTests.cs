using System;
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
    public class AccessTokenConnectionTests
        : ConnectionTestBase<AccessTokenConnection, AccessTokenAuthenticator>
    {
        protected override IAuthenticator CreateMockAuthenticator()
        {
            return Substitute.For<IAuthenticator>();
        }

        protected override AccessTokenConnection CreateMockConnection() => new AccessTokenConnection(
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _mockAuthenticator,
            RemoveConnection);

        protected override void AssertExpectedConnectionCount(int expectedCount) =>
            _connection.ConnectionCount.ShouldBeEquivalentTo(expectedCount, nameof(_connection.ConnectionCount));


        protected override void AssertExpectedSessionCreateCount(int expectedCount) =>
            _mockAuthenticator.Received(expectedCount).Login(Arg.Any<string>());


        protected override void AssertExpectedSessionDeleteCount(int expectedCount) =>
            _mockAuthenticator.Received(expectedCount).Logout();

        protected override void AssertExpectedConnectionRemovalCount(int expectedCount) =>
            _connectionRemovalCount.ShouldBeEquivalentTo(expectedCount, nameof(_connectionRemovalCount));

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
        public void ReAuthenticate_Throws()
        {
            Action action = () => _connection.ReAuthenticate();

            action.ShouldThrow<NotImplementedException>();
        }

        [Test]
        public void ReAuthenticate_WithToken_CreatesNewSessionWithoutDeletingExistingSession()
        {
            var token = _connection.Token();

            _connection.ReAuthenticate(token);

            AssertExpectedSessionCreateCount(2);
            AssertExpectedConnectionCount(1);
            AssertExpectedSessionDeleteCount(0);
            AssertExpectedConnectionRemovalCount(0);

            token.Should().Be(_connection.AccessToken, "a new session token should be created");
        }
    }
}
