using System.Collections.Generic;
using Aquarius.Samples.Client;
using FluentAssertions;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.UnitTests.Samples.Client
{
    [TestFixture]
    public class SamplesServiceClientTests
    {
        private SamplesServiceClient _client;

        [Route("/items", HttpMethods.Get)]
        public class GetItems : IReturnVoid
        {
            public string ScalarText { get; set; }
            public int? ScalarInt { get; set; }
            public IEnumerable<string> ItemFilters { get; set; }
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _client = new SamplesServiceClient("http://example.com/api");
        }

        private static readonly IEnumerable<TestCaseData> GetRequests = new[]
        {
            new TestCaseData("Default properties", new GetItems(), string.Empty),

            new TestCaseData("Only scalar text",
                new GetItems {ScalarText = "Some text"},
                "scalarText=Some%20text"),

            new TestCaseData("Only scalar int",
                new GetItems {ScalarInt = 12},
                "scalarInt=12"),

            new TestCaseData("Both scalar values",
                new GetItems {ScalarText = "Some other text", ScalarInt = -32},
                "scalarText=Some%20other%20text&scalarInt=-32"),

            new TestCaseData("Empty list should not set any property",
                new GetItems{ ItemFilters = new List<string>()},
                string.Empty),

            new TestCaseData("1-item list should set property once",
                new GetItems{ ItemFilters = new List<string>{"once"}},
                "itemFilters=once"),

            new TestCaseData("2-item list should set property once with a list of items",
                new GetItems{ ItemFilters = new List<string>{"once", "twice"}},
                "itemFilters=once%2Ctwice"),
        };

        [TestCaseSource(nameof(GetRequests))]
        public void ResolveTypedUrl_WithRequestProperties_ContainsExpectedQueryParameters(string reason, GetItems request, string expected)
        {
            var actual = GetQueryParametersForRequest(request);

            actual.ShouldBeEquivalentTo(expected, reason);
        }

        private string GetQueryParametersForRequest(object requestDto)
        {
            var url = _client.ResolveTypedUrl(HttpMethods.Get, requestDto);

            var queryIndex = url.IndexOf('?');

            return queryIndex < 0 ? string.Empty : url.Substring(queryIndex+1);
        }
    }
}
