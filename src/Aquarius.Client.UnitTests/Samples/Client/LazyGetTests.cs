using System;
using System.Collections.Generic;
using System.Linq;
using Aquarius.Client.UnitTests.TestHelpers;
using Aquarius.Helpers;
using Aquarius.Samples.Client;
using Aquarius.Samples.Client.ServiceModel;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using ServiceStack;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.UnitTests.Samples.Client
{
    [TestFixture]
    public class LazyGetTests
    {
        private IServiceClient _mockServiceClient;
        private IFixture _fixture;
        private ISamplesClient _client;

        [Route("/things", HttpMethods.Get)]
        public class GetThings : IReturn<ThingResults>, IPaginatedRequest
        {
            public string Cursor { get; set; }
        }

        public class ThingResults: IPaginatedResponse<Thing>
        {
            public int TotalCount { get; set; }
            public string Cursor { get; set; }
            public List<Thing> DomainObjects { get; set; }
        }

        public class Thing
        {
            public string Name { get; set; }
        }


        [SetUp]
        public void ForEachTest()
        {
            _fixture = new Fixture();
            _mockServiceClient = Substitute.For<IServiceClient>();

            SetupMockClient();

            _client = SamplesClient.CreateTestClient(_mockServiceClient);
        }

        private void SetupMockClient()
        {
            _mockServiceClient
                .Get(Arg.Any<GetStatus>())
                .Returns(new Status { ReleaseName = "0.0"});

            _mockServiceClient
                .Get(Arg.Any<SamplesClient.GetUserTokens>())
                .Returns(_fixture.Create<SamplesClient.UserTokensResponse>());
        }

        [Test]
        public void LazyGet_AllResultsInFirstResponse_Succeeds()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => CreateCompleteResults(2));

            var items = EvaluateAllLazyLoadedItems();

            AssertExpectedItemsAndLazyFetches(items, 2, 1);
        }

        private ThingResults CreateCompleteResults(int totalCount)
        {
            if (totalCount < 0)
                throw new ArgumentOutOfRangeException(nameof(totalCount), $"TotalCount={totalCount} must not be negative");

            return CreateResults(totalCount, totalCount);
        }

        private ThingResults CreateFinalResults(int resultCount, int totalCount)
        {
            if (resultCount > totalCount)
                throw new ArgumentOutOfRangeException(nameof(resultCount), $"ResultCount={resultCount} must be less than TotalCount={totalCount}");

            return CreateResults(resultCount, totalCount);
        }

        private ThingResults CreatePartialResults(int resultCount, int totalCount)
        {
            if (resultCount >= totalCount)
                throw new ArgumentOutOfRangeException(nameof(resultCount), $"ResultCount={resultCount} must be strictly less than TotalCount={totalCount}");

            return CreateResults(resultCount, totalCount);
        }

        private ThingResults CreateResultsWithNoCursor(int resultCount, int totalCount)
        {
            var results = CreatePartialResults(resultCount, totalCount);

            results.Cursor = null;

            return results;
        }

        private ThingResults CreateResultsWithEmptyCursor(int resultCount, int totalCount)
        {
            var results = CreatePartialResults(resultCount, totalCount);

            results.Cursor = string.Empty;

            return results;
        }

        private ThingResults CreateResults(int resultCount, int totalCount)
        {
            var results = new ThingResults
            {
                Cursor = _fixture.Create<string>(),
                DomainObjects = new List<Thing>(),
                TotalCount = totalCount
            };

            if (resultCount > 0)
            {
                results.DomainObjects = _fixture.CreateMany<Thing>(resultCount).ToList();
            }
            else
            {
                results.Cursor = null;
            }

            return results;
        }

        private List<Thing> EvaluateAllLazyLoadedItems()
        {
            return _client.LazyGet<Thing, GetThings, ThingResults>(new GetThings(), progressReporter: new ConsoleProgressReporter()).DomainObjects.ToList();
        }

        private void AssertExpectedItemsAndLazyFetches(List<Thing> items, int expectedTotalCount, int expectedFetchesCount)
        {
            items.Count.ShouldBeEquivalentTo(expectedTotalCount, "Total count of items should match");

            _mockServiceClient
                .Received(expectedFetchesCount)
                .Get(Arg.Any<GetThings>());
        }

        [Test]
        public void LazyGet_SecondResponseFails_Throws()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => CreatePartialResults(1, 2),
                    x => { throw new ArgumentException();});

            ((Action) (() => EvaluateAllLazyLoadedItems())).ShouldThrow<ArgumentException>();
        }

        [Test]
        public void LazyGet_SecondResponseContainsAllRemainingItems_Succeeds()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => CreatePartialResults(1, 3),
                    x => CreateFinalResults(1, 2));

            var items = EvaluateAllLazyLoadedItems();

            AssertExpectedItemsAndLazyFetches(items, 2, 2);
        }

        [Test]
        public void LazyGet_SecondResponseWithNoCursor_Succeeds()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => CreatePartialResults(1, 3),
                    x => CreateResultsWithNoCursor(1, 3));

            var items = EvaluateAllLazyLoadedItems();

            AssertExpectedItemsAndLazyFetches(items, 2, 2);
        }

        [Test]
        public void LazyGet_SecondResponseWithEmptyCursor_Succeeds()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => CreatePartialResults(1, 3),
                    x => CreateResultsWithEmptyCursor(1, 3));

            var items = EvaluateAllLazyLoadedItems();

            AssertExpectedItemsAndLazyFetches(items, 2, 2);
        }

        [Test]
        public void LazyGet_ResponseWithNullObjects_Succeeds()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => new ThingResults {TotalCount = 1, DomainObjects = null});

            var items = EvaluateAllLazyLoadedItems();

            AssertExpectedItemsAndLazyFetches(items, 0, 1);
        }
        [Test]
        public void LazyGet_ResponseWithEmptyObjects_Succeeds()
        {
            _mockServiceClient
                .Get(Arg.Any<GetThings>())
                .Returns(
                    x => new ThingResults {TotalCount = 1, DomainObjects = new List<Thing>()});

            var items = EvaluateAllLazyLoadedItems();

            AssertExpectedItemsAndLazyFetches(items, 0, 1);
        }
    }
}
