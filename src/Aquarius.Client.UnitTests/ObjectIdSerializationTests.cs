using System.Collections.Generic;
using Aquarius.Client.Helpers;
using FluentAssertions;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.Client.UnitTests
{
    [TestFixture]
    public class ObjectIdSerializationTests
    {
        [SetUp]
        public void ForEachTest()
        {
            ServiceStackConfig.ConfigureServiceStack();
        }

        private static readonly IEnumerable<TestCaseData> ObjectIdCases = new[]
        {
            new TestCaseData("Empty object Id", new ObjectId(), "\"0\""),
            new TestCaseData("Valid object Id", new ObjectId(12), "\"12\""),
        };

        [TestCaseSource("ObjectIdCases")]
        public void ObjectId_DeserializesFromJsonCorrectly(string reason, ObjectId expectedObjectId, string objectIdAsJson)
        {
            var actualObjectId = objectIdAsJson.FromJson<ObjectId>();
            ((long)actualObjectId).ShouldBeEquivalentTo((long)expectedObjectId, reason);
        }

        [TestCaseSource("ObjectIdCases")]
        public void ObjectId_SerializesToJsonCorrectly(string reason, ObjectId objectId, string objectIdAsJson)
        {
            var actualJson = objectId.ToJson();
            actualJson.ShouldBeEquivalentTo(objectIdAsJson, reason);
        }
    }
}
