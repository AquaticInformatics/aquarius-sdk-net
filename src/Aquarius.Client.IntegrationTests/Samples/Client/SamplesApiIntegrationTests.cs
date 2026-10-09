using System;
using Aquarius.Samples.Client;
using Aquarius.Samples.Client.ServiceModel;
using NUnit.Framework;

namespace Aquarius.Client.IntegrationTests.Samples.Client
{
    [TestFixture]
    [Category("SamplesIntegration")]
    [Explicit("Requires Samples API credentials and creates records that are left for inspection.")]
    public class SamplesApiIntegrationTests
    {
        private ISamplesClient _client;

        [SetUp]
        public void ForEachTest()
        {
            var baseUrl = Environment.GetEnvironmentVariable("SAMPLES_CLIENT");
            var token = Environment.GetEnvironmentVariable("SAMPLES_TOKEN");

            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(token))
                Assert.Fail("Set SAMPLES_CLIENT and SAMPLES_TOKEN before running the Samples integration tests.");

            _client = SamplesClient.CreateConnectedClient(baseUrl, token);
            TestContext.WriteLine($"Connected to Samples ({_client.ServerVersion}).");
        }

        [TearDown]
        public void AfterEachTest()
        {
            _client?.Dispose();
            _client = null;
        }

        [Test]
        public void GetActivities_ConnectedClient_ReturnsSearchResultActivities()
        {
            var result = _client.Get(new GetActivities {Limit = 1});

            Assert.That(result, Is.Not.Null);
            Assert.That(result.TotalCount, Is.GreaterThanOrEqualTo(0));
            Assert.That(result.DomainObjects, Is.Not.Null);
            TestContext.WriteLine($"Found {result.TotalCount} activities.");
        }

        [Test]
        public void PostAndPutActivity_WithExternalTrackingFields_PersistsValues()
        {
            var fieldVisit = CreateTrackingFieldVisit();
            var trackingId = Guid.NewGuid().ToString();
            var trackingName = "tracking-" + Guid.NewGuid();
            var created = _client.Post(new PostActivity
            {
                Type = ActivityType.SAMPLE_ROUTINE,
                CustomId = "tracking-test-" + Guid.NewGuid(),
                StartTime = DateTimeOffset.UtcNow,
                SamplingLocation = fieldVisit.SamplingLocation,
                FieldVisit = fieldVisit,
                Medium = new Medium {SystemCode = MediumSystemCodeType.WATER},
                ExternalTrackingId = trackingId,
                ExternalTrackingName = trackingName
            });

            Assert.That(created.Id, Is.Not.Null.And.Not.Empty);
            TestContext.WriteLine($"Created activity: {created.Id} (custom ID: {created.CustomId}).");
            Assert.That(created.ExternalTrackingId, Is.EqualTo(trackingId));
            Assert.That(created.ExternalTrackingName, Is.EqualTo(trackingName));

            var fetched = _client.Get(new GetActivity {Id = created.Id});
            Assert.That(fetched.ExternalTrackingId, Is.EqualTo(trackingId));
            Assert.That(fetched.ExternalTrackingName, Is.EqualTo(trackingName));

            var updatedTrackingName = "tracking-" + Guid.NewGuid();
            var updated = _client.Put(new PutActivity
            {
                Id = fetched.Id,
                Type = fetched.Type,
                CustomId = fetched.CustomId,
                StartTime = fetched.StartTime,
                EndTime = fetched.EndTime,
                SamplingLocation = fetched.SamplingLocation,
                FieldVisit = fetched.FieldVisit,
                Medium = fetched.Medium,
                ExternalTrackingId = trackingId,
                ExternalTrackingName = updatedTrackingName
            });

            Assert.That(updated.ExternalTrackingId, Is.EqualTo(trackingId));
            Assert.That(updated.ExternalTrackingName, Is.EqualTo(updatedTrackingName));

            var persisted = _client.Get(new GetActivity {Id = created.Id});
            Assert.That(persisted.ExternalTrackingId, Is.EqualTo(trackingId));
            Assert.That(persisted.ExternalTrackingName, Is.EqualTo(updatedTrackingName));
        }

        private FieldVisit CreateTrackingFieldVisit()
        {
            var location = _client.Post(new PostSamplingLocation
            {
                CustomId = "tracking-test-" + Guid.NewGuid()
            });
            Assert.That(location.Id, Is.Not.Null.And.Not.Empty);
            TestContext.WriteLine($"Created sampling location: {location.Id} (custom ID: {location.CustomId}).");

            var fieldVisit = _client.Post(new PostFieldVisit
            {
                StartTime = DateTimeOffset.UtcNow,
                PlanningStatus = PlanningStatusType.IN_PROGRESS,
                SamplingLocation = location
            });
            Assert.That(fieldVisit.Id, Is.Not.Null.And.Not.Empty);
            TestContext.WriteLine($"Created field visit: {fieldVisit.Id}.");

            return fieldVisit;
        }
    }
}
