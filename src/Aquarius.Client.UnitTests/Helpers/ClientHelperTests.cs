using System;
using Aquarius.Client.Helpers;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using ServiceStack;

namespace Aquarius.Client.UnitTests.Helpers
{
    [TestFixture]
    public class ClientHelperTests
    {
        private JsonServiceClient _rawClient;
        private IFixture _fixture;

        [SetUp]
        public void ForEachTest()
        {
            _rawClient = new JsonServiceClient();
            _fixture = new Fixture();
        }

        [Test]
        public void SetAuthenticationToken_NoExistingToken_NewTokenIsAdded()
        {
            AssertThatNoTokenExists();

            var newToken = _fixture.Create<string>();

            SetAuthenticationToken(newToken);

            AssertThatTokenMatchesExpected(newToken);
        }

        private void SetAuthenticationToken(string token)
        {
            ClientHelper.SetAuthenticationToken(_rawClient, token);
        }

        private void AssertThatNoTokenExists()
        {
            Assert.That(_rawClient.Headers[AuthenticationHeaders.AuthenticationHeaderNameKey], Is.Null);
        }

        private void AssertThatTokenMatchesExpected(string expectedToken)
        {
            _rawClient.Headers[AuthenticationHeaders.AuthenticationHeaderNameKey].ShouldBeEquivalentTo(expectedToken);
        }

        [Test]
        public void SetAuthenticationToken_ExistingToken_NewTokenIsAdded()
        {
            var token1 = _fixture.Create<string>();
            var token2 = _fixture.Create<string>();

            Assert.That(token1, Is.Not.EqualTo(token2));

            SetAuthenticationToken(token1);

            AssertThatTokenMatchesExpected(token1);

            SetAuthenticationToken(token2);

            AssertThatTokenMatchesExpected(token2);
        }

        [Test]
        public void CloneAuthenticatedClient_WithNullClient_Throws()
        {
            Action action = () => ClientHelper.CloneAuthenticatedClient(null, string.Empty);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void CloneAuthenticatedClient_WithValidClient_ClonesAuthenticationToken()
        {
            var token = _fixture.Create<string>();

            SetAuthenticationToken(token);

            var baseUri = _fixture.Create<string>();
            var clone = ClientHelper.CloneAuthenticatedClient(_rawClient, baseUri);

            clone.Headers[AuthenticationHeaders.AuthenticationHeaderNameKey].ShouldBeEquivalentTo(_rawClient.Headers[AuthenticationHeaders.AuthenticationHeaderNameKey]);
        }
    }
}
