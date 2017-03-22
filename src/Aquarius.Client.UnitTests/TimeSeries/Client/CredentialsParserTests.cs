using System;
using System.Collections.Generic;
using Aquarius.TimeSeries.Client;
using FluentAssertions;
using NUnit.Framework;

namespace Aquarius.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class CredentialsParserTests
    {
        [Test]
        public void Consructor_WithNullUri_Throws()
        {
            Action action = () => CreateParser(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        private static CredentialsParser CreateParser(Uri uri)
        {
            return new CredentialsParser(uri);
        }

        private static CredentialsParser CreateParser()
        {
            return CreateParser(new Uri("user:pass@server"));
        }

        private static readonly IEnumerable<TestCaseData> SaneUriTests = new []
        {
            new TestCaseData("http://server/path", "http://server/path", "A simple HTTP URI round trips"),
            new TestCaseData("http://server", "http://server/", "Only a HTTP server name gets a root path appended"),
            new TestCaseData("http://server:80/path", "http://server/path", "Default HTTP port is removed"),
            new TestCaseData("http://server:443/path", "http://server:443/path", "Non-default HTTP port remains"),
            new TestCaseData("https://server", "https://server/", "Only a HTTPS server name gets a root path appended"),
            new TestCaseData("https://server:443/path", "https://server/path", "Default HTTPS port is removed"),
            new TestCaseData("https://server:80/path", "https://server:80/path", "Non-default HTTPS port remains"),
            new TestCaseData("user:pass@server", "http://user:pass@server/", "Bare minimum HTTP credentials"),
            new TestCaseData("https://user:pass@server", "https://user:pass@server/", "Bare minimum HTTPS credentials"),
        };

        [TestCaseSource("SaneUriTests")]
        public void Uris_SanitizeAsExpected(string sourceUri, string expected, string reason)
        {
            var parser = CreateParser(new Uri(sourceUri));

            var actual = parser.Uri.ToString();

            actual.ShouldBeEquivalentTo(expected, reason);
        }

        [TestCaseSource("SaneUriTests")]
        public void Uris_RoundTripCorrectly(string sourceUri, string expected, string reason)
        {
            var parser = CreateParser();

            parser.Uri = new Uri(expected);

            var actual = parser.Uri.ToString();

            actual.ShouldBeEquivalentTo(expected, reason);
        }

        private static readonly IEnumerable<TestCaseData> ServerNameTests = new[]
        {
            new TestCaseData("http://server", "server", "Default scheme is stripped"),
            new TestCaseData("http://server:80", "server", "Default HTTP port is stripped"),
            new TestCaseData("http://server:443", "server:443", "Non-default HTTP port is retained"),
            new TestCaseData("https://server", "https://server", "Minimum HTTPS representation"),
            new TestCaseData("https://server:443", "https://server", "Default HTTPS port is stripped"),
            new TestCaseData("https://server:80", "https://server:80", "Non-default HTTPS port is retains"),
        };

        [TestCaseSource("ServerNameTests")]
        public void ServerName_MatchesExpected(string sourceUri, string expected, string reason)
        {
            var parser = CreateParser(new Uri(sourceUri));

            var actual = parser.ServerName;

            actual.ShouldBeEquivalentTo(expected, reason);
        }

        [TestCaseSource("ServerNameTests")]
        public void ServerName_RoundTripsCorrectly(string sourceUri, string expected, string reason)
        {
            var parser = CreateParser(new Uri(sourceUri));

            parser.ServerName = "dummyservernametoclearthingsout";
            parser.ServerName = expected;

            var actual = parser.ServerName;

            actual.ShouldBeEquivalentTo(expected, reason);
        }

        private static readonly IEnumerable<TestCaseData> NullOrWhitespaceServerNames = new[]
        {
            new TestCaseData(null, "Null"),
            new TestCaseData(string.Empty, "Empty string"),
            new TestCaseData(" ", "Whitespace"),
        };

        [TestCaseSource("NullOrWhitespaceServerNames")]
        public void ServerName_SetNullOrWhitespace_Throws(string invalidValue, string reason)
        {
            string.IsNullOrWhiteSpace(invalidValue).ShouldBeEquivalentTo(true, "Invalid test case");

            var parser = CreateParser();

            Action action = () => parser.ServerName = invalidValue;

            action.ShouldThrow<ArgumentException>(reason);
        }

        private static readonly IEnumerable<TestCaseData> CredentialTests = new[]
        {
            new TestCaseData("user:pass@server", "user", "pass", "Simplest case"),
            new TestCaseData("http://user%3A:pass@server", "user:", "pass", "Percent encoded username"),
            new TestCaseData("http://user%3a:pass@server", "user:", "pass", "Percent encoded (but lowercase) username"),
            new TestCaseData("http://user:pass%40@server", "user", "pass@", "Percent encoded password"),
            new TestCaseData("http://user%3A:pass%40@server", "user:", "pass@", "Both encoded"),
        };

        [TestCaseSource("CredentialTests")]
        public void Credentials_MatchExpected(string sourceUri, string expectedUserName, string expectedPassword, string reason)
        {
            var parser = CreateParser(new Uri(sourceUri));

            var actualUser = parser.UserName;
            var actualPassword = parser.Password;

            actualUser.ShouldBeEquivalentTo(expectedUserName, "UserName: " + reason);
            actualPassword.ShouldBeEquivalentTo(expectedPassword, "Password: " + reason);
        }

        [TestCaseSource("CredentialTests")]
        public void Credentials_RoundTripCorrectly(string sourceUri, string expectedUserName, string expectedPassword, string reason)
        {
            var parser = CreateParser(new Uri(sourceUri));

            parser.UserName = string.Empty;
            parser.Password = string.Empty;

            parser.UserName = expectedUserName;
            parser.Password = expectedPassword;

            var actualUser = parser.UserName;
            var actualPassword = parser.Password;

            actualUser.ShouldBeEquivalentTo(expectedUserName, "UserName: " + reason);
            actualPassword.ShouldBeEquivalentTo(expectedPassword, "Password: " + reason);
        }

        [Test]
        public void UserName_SetNullValue_Throws()
        {
            var parser = CreateParser();

            Action action = () => parser.UserName = null;

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Password_SetNullValue_Throws()
        {
            var parser = CreateParser();

            Action action = () => parser.Password = null;

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Password_SetEmpty_ResetsBothValues()
        {
            var parser = CreateParser();

            Assert.That(string.IsNullOrEmpty(parser.Password), Is.Not.True, "Invalid test case");
            Assert.That(string.IsNullOrEmpty(parser.UserName), Is.Not.True, "Invalid test case");

            parser.Password = string.Empty;

            var expected = string.Empty;

            parser.Password.ShouldBeEquivalentTo(expected);
            parser.UserName.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void UserName_SetEmpty_ResetsBothValues()
        {
            var parser = CreateParser();

            Assert.That(string.IsNullOrEmpty(parser.Password), Is.Not.True, "Invalid test case");
            Assert.That(string.IsNullOrEmpty(parser.UserName), Is.Not.True, "Invalid test case");

            parser.UserName = string.Empty;

            var expected = string.Empty;

            parser.Password.ShouldBeEquivalentTo(expected);
            parser.UserName.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Merge_NullUri_Throws()
        {
            var parser = CreateParser();

            Action action = () => parser.Merge(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        private static readonly IEnumerable<TestCaseData> MergeTests = new[]
        {
            new TestCaseData("http://server", "http://server2", "http://server2/", "Server name merges"),
            new TestCaseData("http://server", "https://server", "https://server/", "Scheme merges"),
            new TestCaseData("http://server", "http://server:8080", "http://server:8080/", "Scheme merges"),
            new TestCaseData("http://server", "user:pass@server", "http://user:pass@server/", "Credentials are merged"),
        };

        [TestCaseSource("MergeTests")]
        public void Merge_SourceUri_MergesIntoTarget(string targetUri, string sourceUri, string expected, string reason)
        {
            var parser = CreateParser(new Uri(targetUri));

            parser.Merge(new Uri(sourceUri));

            var actual = parser.Uri.ToString();

            actual.ShouldBeEquivalentTo(expected, reason);
        }
    }
}
