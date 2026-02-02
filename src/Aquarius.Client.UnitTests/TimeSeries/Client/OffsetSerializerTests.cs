using Aquarius.TimeSeries.Client;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace Aquarius.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class OffsetSerializerTests
    {
        [SetUp]
        public void ForEachTest()
        {
            ServiceStackConfig.ConfigureServiceStack();
        }

        private static readonly Offset? Negative8 = Offset.FromTicks(TimeSpan.FromHours(-8).Ticks);
        private static readonly Offset? UtcOffset = Offset.FromTicks(0);
        private static readonly Offset? Positive9Point5 = Offset.FromTicks(TimeSpan.FromHours(9.5).Ticks); 
        private static readonly Offset? Positive10 = Offset.FromTicks(TimeSpan.FromHours(10).Ticks);
        
        private static readonly IEnumerable<TestCaseData> OffsetCases = new[]
        {
            new TestCaseData("Negative offset", Negative8.Value, "\"-PT8H\""),
            new TestCaseData("Utc offset", UtcOffset.Value, "\"PT0S\""),
            new TestCaseData("Positive offset", Positive10.Value, "\"PT10H\""),
            new TestCaseData("Positive offset with hours and minutes", Positive9Point5.Value, "\"PT9H30M\""),
            new TestCaseData("Null offset", null, "\"PT0S\"")
        };

        private static readonly IEnumerable<TestCaseData> NullableOffsetCases = new[]
        {
            new TestCaseData("Negative offset", Negative8, "\"-PT8H\""),
            new TestCaseData("Utc offset", UtcOffset, "\"PT0S\""),
            new TestCaseData("Positive offset", Positive10, "\"PT10H\""),
            new TestCaseData("Positive offset with hours and minutes", Positive9Point5, "\"PT9H30M\""),
            new TestCaseData("Null offset", null, null)
        };

        [TestCaseSource("OffsetCases")]
        public void Offset_DeserializesFromJsonCorrectly(string reason, Offset expectedOffset, string offsetAsJson)
        {
            var actualOffset = offsetAsJson.FromJson<Offset>();
            ((Offset)actualOffset).ShouldBeEquivalentTo(expectedOffset, reason);
        }

        [TestCaseSource("OffsetCases")]
        public void Offset_SerializesToJsonCorrectly(string reason, Offset offset, string offsetAsJson)
        {
            var actualJson = offset.ToJson();
            actualJson.ShouldBeEquivalentTo(offsetAsJson, reason);
        }

        [TestCaseSource("NullableOffsetCases")]
        public void NullableOffset_DeserializesFromJsonCorrectly(string reason, Offset? expectedOffset, string offsetAsJson)
        {
            var actualOffset = offsetAsJson.FromJson<Offset?>();
            ((Offset?)actualOffset).ShouldBeEquivalentTo(expectedOffset, reason);
        }

        [TestCaseSource("NullableOffsetCases")]
        public void NullableOffset_SerializesToJsonCorrectly(string reason, Offset? offset, string offsetAsJson)
        {
            var actualJson = offset.ToJson();
            actualJson.ShouldBeEquivalentTo(offsetAsJson, reason);
        }
    }
}
