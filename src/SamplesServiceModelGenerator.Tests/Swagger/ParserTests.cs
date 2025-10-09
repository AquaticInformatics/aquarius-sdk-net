using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SamplesServiceModelGenerator.Swagger;
using System.Text.RegularExpressions;

namespace SamplesServiceModelGenerator.Tests.Swagger
{
    [TestFixture]
    public class ParserTests
    {
        private string baseUrl = "https://demo.aqsamples.com/api/swagger.json";
        private string jsonText = "";

        private string _enums = string.Join(";",
                                "ActivityType=type.SAMPLE_INTEGRATED_VERTICAL_PROFILE,SAMPLE_ROUTINE,QC_SAMPLE_REPLICATE,QC_TRIP_BLANK,FIELD_SURVEY,NONE",
                                "AnalyticalGroupType=type.KNOWN,UNKNOWN",
                                "ImportItemStatusType=status.ERROR,NEW,UPDATE,EXPECTED,SKIPPED",
                                "SpecimenViewStatusType=status.REQUESTED,RECEIVED_SOME,RECEIVED_ALL");
        private static readonly char[] ItemSeparators = { ';' };
        private static readonly Regex EnumRegex = new Regex(@"^\s*(?<enumName>[^= ]+)\s*=\s*(?<fieldName>[^. ]+)\s*\.\s*(?<valueList>[^ ]+)\s*$", RegexOptions.Compiled);
        private static readonly char[] ListSeparators = { ',', ' ' };

        private Parser testparser = new Parser();
        private Api parseOutput = new Api();
        private JObject json = new JObject();

        private string LoadStringFromUrl(string url)
        {
            var uri = new Uri(url);

            Console.WriteLine($"Fetching {uri} ...");

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(uri).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        [SetUp]
        public void ForEachTest()
        {
            jsonText = LoadStringFromUrl(baseUrl);

            testparser = new Parser {
                EnumOverrides = _enums
                    .Split(ItemSeparators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => EnumRegex.Match(s))
                    .Where(m => m.Success)
                    .ToDictionary(
                        m => $"{m.Groups["fieldName"].Value.Trim()}.{string.Join(",", m.Groups["valueList"].Value.Split(ListSeparators, StringSplitOptions.RemoveEmptyEntries))}",
                        m => new SamplesServiceModelGenerator.Swagger.Enum(
                            new Property { Name = m.Groups["enumName"].Value.Trim() },
                            new Property { Name = m.Groups["enumName"].Value.Trim() },
                            m.Groups["valueList"].Value.Split(ListSeparators, StringSplitOptions.RemoveEmptyEntries)))
            };

            try
            {
                json = JObject.Parse(jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("Test Swagger is not a Valid Json", ex);
            }

            parseOutput = testparser.Parse(jsonText, baseUrl);
        }

        [Test]
        public void ParseBaseUrl()
        {
            Assert.AreEqual(baseUrl, parseOutput.BaseUrl);
        }

        [Test]
        public void ParseTitle()
        {
            Assert.AreEqual(json["info"]["title"].ToString(), parseOutput.Title);
        }

        [Test]
        public void ParseDefinitions()
        {
            parseOutput.Definitions.Should().NotBeEmpty();

            parseOutput.Definitions.Count().Equals(json["definitions"].Count());

            JObject expectedDefinitions = (JObject)json["definitions"];
            List<String> expectedProperties = ["message", "localizationKey", "localizationParameters", "requestId", "id", "name", "description", "canEditAllData", "samplingLocationGroups", "auditAttributes"];

            foreach (Definition parsedDefinition in parseOutput.Definitions)
            {
                Assert.IsTrue(expectedDefinitions.ContainsKey(parsedDefinition.Name.ToString()));
                foreach (Property parsedProperty in parsedDefinition.Properties)
                {
                    expectedProperties.Contains(parsedProperty.Name);
                }
            }

        }

        [Test]
        public void ParsePaths()
        {
            parseOutput.Paths.Should().NotBeEmpty();

            parseOutput.Paths.Count().Equals(json["paths"].Count());

            JObject expectedPaths = (JObject)json["paths"];
            List<String> expectedOperationKeys = ["getLaboratories", "postLaboratory", "addOrUpdateIndex", "getFilterHistory", "getSpecimenHistory", "getActivities", "postActivity", "deleteActivities"];

            foreach (SamplesServiceModelGenerator.Swagger.Path parsedPath in parseOutput.Paths)
            {
                Assert.IsTrue(expectedPaths.ContainsKey(parsedPath.Route.ToString()));
                foreach (Operation parsedOperation in parsedPath.Operations.Values)
                {
                    expectedOperationKeys.Contains(parsedOperation.OperationId);
                }
            }

        }

        [Test]
        public void ParseEnums()
        {
            parseOutput.Enums.Should().NotBeEmpty();
        }

    }
}
