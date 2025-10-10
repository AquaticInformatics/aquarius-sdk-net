using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SamplesServiceModelGenerator.Swagger;
using Property = SamplesServiceModelGenerator.Swagger.Property;

namespace SamplesServiceModelGenerator.Tests.Swagger
{
    [TestFixture]
    public class ParserTests
    {
        const string _baseUrl = "https://demo.aqsamples.com/api/swagger.json";
        private string _jsonText = "";
        private Parser _testparser = new Parser();
        private Api _parseOutput = new Api();
        private JObject _json = new JObject();

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

        [OneTimeSetUp]
        public void BeforeAll()
        {
            _jsonText = LoadStringFromUrl(_baseUrl);

            try
            {
                _json = JObject.Parse(_jsonText);
            }
            catch (Exception ex)
            {
                throw new Exception("Test Swagger is not a Valid Json", ex);
            }
            _parseOutput = _testparser.Parse(_jsonText, _baseUrl);
        }

        [Test]
        public void Parse_SamplesSwaggerDoc_Succeeds()
        {
            AssertExpectedBaseUrl();
            AssertExpectedTitle();
            AssertExpectedDefinitions();
            AssertExpectedPaths();
            AssertExpectedEnums();
        }

        [Test]
        public void Parse_InvalidSamplesSwaggerDoc_Throws()
        {
            var invalidJson = "{ baseUrl: invalidUrl, title: fakeTitle }";
            Assert.Throws<ExpectedException>(() => _testparser.Parse(invalidJson, _baseUrl));
        }

        public void AssertExpectedBaseUrl()
        {
            Assert.AreEqual(_baseUrl, _parseOutput.BaseUrl);
        }

        public void AssertExpectedTitle()
        {
            Assert.AreEqual(_json["info"]["title"].ToString(), _parseOutput.Title);
        }

        public void AssertExpectedDefinitions()
        {
            _parseOutput.Definitions.Should().NotBeEmpty();

            _parseOutput.Definitions.Count().Equals(_json["definitions"].Count());

            var expectedDefinitions = _json["definitions"] as JObject;
            var expectedProperties = new List<string>();

            foreach (var def in expectedDefinitions.Properties())
            {
                var expectedDefinition = (JObject)def.Value;
                var properties = expectedDefinition["properties"] as JObject;

                if (properties != null)
                {
                    foreach (var prop in properties.Properties())
                    {
                        expectedProperties.Add(prop.Name);
                    }
                }
            }

            foreach (Definition parsedDefinition in _parseOutput.Definitions)
            {
                Assert.IsTrue(expectedDefinitions.ContainsKey(parsedDefinition.Name));
                foreach (Property parsedProperty in parsedDefinition.Properties)
                {
                    Assert.IsTrue(expectedProperties.Contains(parsedProperty.Name));
                }
            }
        }

        public void AssertExpectedPaths()
        {
            _parseOutput.Paths.Should().NotBeEmpty();

            _parseOutput.Paths.Count().Equals(_json["paths"].Count());

            var expectedPaths = _json["paths"] as JObject;
            List<string> verbs = ["get", "delete", "post", "put"];
            var expectedOperationIds = new List<string>();
            var parsedOperationIds = new List<string>();

            foreach (var path in expectedPaths.Properties())
            {
                var pathItem = (JObject)path.Value;

                foreach (var verb in verbs)
                {
                    if (pathItem.TryGetValue(verb, out var verbObj))
                    {
                        var operationId = verbObj["operationId"]?.ToString();
                        if (!string.IsNullOrEmpty(operationId))
                        {
                            expectedOperationIds.Add(operationId);
                        }
                    }
                }
            }

            foreach (SamplesServiceModelGenerator.Swagger.Path parsedPath in _parseOutput.Paths)
            {
                Assert.IsTrue(expectedPaths.ContainsKey(parsedPath.Route));
                foreach (Operation parsedOperation in parsedPath.Operations.Values)
                {
                    parsedOperationIds.Add(parsedOperation.OperationId);
                }
            }
            parsedOperationIds.Count().Equals(expectedOperationIds.Count());
        }

        public void AssertExpectedEnums()
        {
            _parseOutput.Enums.Should().NotBeEmpty();
        }

    }
}
