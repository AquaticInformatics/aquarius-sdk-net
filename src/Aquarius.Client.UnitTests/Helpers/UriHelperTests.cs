using System;
using System.Collections.Generic;
using Aquarius.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Aquarius.UnitTests.Helpers
{
    [TestFixture]
    public class UriHelperTests
    {
        private static readonly IEnumerable<TestCaseData> ResolveTests = new[]
        {
            new TestCaseData("localhost", "/api", null, "http://localhost/api", "Plain host with null default scheme defaults to HTTP"),
            new TestCaseData("localhost", "/api", Uri.UriSchemeFtp, "ftp://localhost/api", "Plain host with a default scheme defaults to the given scheme"),
            new TestCaseData("https://localhost", "/api", Uri.UriSchemeFtp, "https://localhost/api", "Host with a scheme does not receive the default scheme"),
            new TestCaseData("123.123.123.123", "/api", null, "http://123.123.123.123/api", "IPv4 host with null default scheme defaults to HTTP"),
            new TestCaseData("http://123.123.123.123:55", "/api", null, "http://123.123.123.123:55/api", "IPv4 host with non-standard port and null default scheme defaults to HTTP"),
            new TestCaseData("https://localhost/somepath", "/api", null, "https://localhost/api", "Host with a path replaces path with the endpoint"),
        };

        [TestCaseSource(nameof(ResolveTests))]
        public void ResolveUri_ResolvestoExpectedUrl(string host, string endpoint, string defaultScheme, string expectedUrl, string reason)
        {
            var actual = UriHelper.ResolveUri(host, endpoint, defaultScheme).ToString();

            actual.ShouldBeEquivalentTo(expectedUrl, reason);
        }

        [TestCaseSource(nameof(ResolveTests))]
        public void ResolveEndpoint_ResolvestoExpectedUrl(string host, string endpoint, string defaultScheme, string expectedUrl, string reason)
        {
            var actual = UriHelper.ResolveEndpoint(host, endpoint, defaultScheme);

            actual.ShouldBeEquivalentTo(expectedUrl, reason);
        }

        private static readonly IEnumerable<TestCaseData> InvalidArgumentTests = new[]
        {
            new TestCaseData(null, "/api", "Null host should throw"),
            new TestCaseData(string.Empty, "/api", "Empty host should throw"),
            new TestCaseData("somehost", null, "Null endpoint should throw"),
            new TestCaseData("somehost", string.Empty, "Empty endpoint should throw"),
            new TestCaseData("123.123.123.123:55", "/api", "IPv4 with port but no scheme should throw"), 
        };

        [TestCaseSource(nameof(InvalidArgumentTests))]
        public void ResolveUri_WithInvalidArguments_Throws(string host, string endpoint, string reason)
        {
            Action action = () => UriHelper.ResolveUri(null, "/api");

            action.ShouldThrow<UriFormatException>();
        }

        [TestCaseSource(nameof(InvalidArgumentTests))]
        public void ResolveEndpoint_WithInvalidArguments_Throws(string host, string endpoint, string reason)
        {
            Action action = () => UriHelper.ResolveEndpoint(null, "/api");

            action.ShouldThrow<UriFormatException>();
        }
    }
}
