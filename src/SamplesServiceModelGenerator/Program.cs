using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using SamplesServiceModelGenerator.CodeGenerators;
using SamplesServiceModelGenerator.Swagger;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using Enum = SamplesServiceModelGenerator.Swagger.Enum;
using Path = System.IO.Path;

namespace SamplesServiceModelGenerator
{
    public class Program
    {
        private static ILog _log;

        public static void Main(string[] args)
        {
            try
            {
                Environment.ExitCode = 1;

                ConfigureLogging();

                var program = new Program();

                program.ParseArgs(args);
                program.Run();

                Environment.ExitCode = 0;
            }
            catch (ExpectedException exception)
            {
                _log.Error(exception.Message);
            }
            catch (Exception exception)
            {
                _log.Error(exception.Message, exception);
            }
        }

        private static void ConfigureLogging()
        {
            LogManager.LogFactory = new Log4NetFactory(configureLog4Net: true);

            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        private class Option
        {
            public string Key { get; set; }
            public string Description { get; set; }
            public Action<string> Setter { get; set; }
            public Func<string> Getter { get; set; }

            public string UsageText()
            {
                var defaultValue = Getter();

                if (!string.IsNullOrEmpty(defaultValue))
                    defaultValue = $" [default: {defaultValue}]";

                return $"{Key,-20} {Description}{defaultValue}";
            }
        }

        private static readonly Regex ArgRegex = new Regex(@"^([/-])(?<key>[^=]+)=(?<value>.*)$", RegexOptions.Compiled);

        private string _usageMessage;
        private string _url = "https://demo.aqsamples.com/api/swagger.json";
        private TargetLanguage _targetLanguage = TargetLanguage.CSharp;

        private Dictionary<TargetLanguage, string> _namespace = new Dictionary<TargetLanguage, string>
        {
            {TargetLanguage.CSharp, "Aquarius.Samples.Client.ServiceModel"},
            {TargetLanguage.Java, "com.aquaticinformatics.aquarius.sdk.samples"},
        };

        private Dictionary<TargetLanguage, string> _usingDirectives = new Dictionary<TargetLanguage, string>
        {
            {TargetLanguage.CSharp, "System.Collections.Generic;ServiceStack;NodaTime;Aquarius.TimeSeries.Client"},
            {TargetLanguage.Java, "java.time.*;java.util.*;net.servicestack.client.*;com.aquaticinformatics.aquarius.sdk.AquariusServerVersion"},
        };

        private Dictionary<TargetLanguage, string> _filename = new Dictionary<TargetLanguage, string>
        {
            {TargetLanguage.CSharp, "ServiceModel.cs"},
            {TargetLanguage.Java, "ServiceModel.java"},
        };

        private Dictionary<TargetLanguage, string> _aliases = new Dictionary<TargetLanguage, string>
        {
            {TargetLanguage.CSharp, "DomainDateTime=Timestamp;DomainDateTimeRange=TimeRange"},
            {TargetLanguage.Java, "DomainDateTime=Timestamp;DomainDateTimeRange=TimeRange"},
        };

        private string _fixups = "GET:/v1/samplinglocations/{id}/attachments=GetSamplingLocationAttachments;"
                                 + "GET:/v1/fieldvisits/{id}/attachments=GetFieldVisitAttachments;"
                                 + "GET:/v1/unitgroupwithunits=GetUnitGroupsWithUnits;"
                                 + "GET:/v1/unitgroupwithunits/{id}=GetUnitGroupWithUnits;"
                                 + "PUT:/v1/unitgroupwithunits/{id}=PutSparseUnitGroupWithUnits;"
                                 + "DELETE:/v1/unitgroupwithunits/{id}=DeleteUnitGroupWithUnitsById;"
                                 + "GET:/v1/units=GetUnits;"
                                 + "POST:/v1/fieldvisits/{id}/activityfromplannedactivity=PostActivityFromPlannedActivity;"
                                 + "POST:/v1/fieldvisits/{id}/activitywithtemplate=PostActivityWithTemplate;"
                                 ;

        private string _enums = "ActivityType=type.SAMPLE_INTEGRATED_VERTICAL_PROFILE,SAMPLE_ROUTINE,QC_SAMPLE_REPLICATE,QC_TRIP_BLANK,FIELD_SURVEY,NONE;"
                                + "AnalyticalGroupType=type.KNOWN,UNKNOWN;"
                                + "ImportItemStatusType=status.ERROR,NEW,UPDATE,EXPECTED,SKIPPED;"
                                + "SpecimenViewStatusType=status.REQUESTED,RECEIVED_SOME,RECEIVED_ALL;"
                                ;

        private void ParseArgs(string[] args)
        {
            var options = new[]
            {
                new Option {Key = "Language", Setter = value => _targetLanguage = (TargetLanguage)System.Enum.Parse(typeof(TargetLanguage), value, true), Getter = () => _targetLanguage.ToString(), Description = $"Language for the generated service model code. One of: {string.Join(", ", System.Enum.GetNames(typeof(TargetLanguage)))}. This option should be set before setting any -Namespace, -UsingDirectives, or -Aliases options."},
                new Option {Key = "URL", Setter = value => _url = value, Getter = () => _url, Description = "URL for Swagger 2.0 JSON"},
                new Option {Key = "Filename", Setter = value => _filename[_targetLanguage] = value, Getter = () => _filename[_targetLanguage], Description = "Filename for the generated service model code"},
                new Option {Key = "Namespace", Setter = value => _namespace[_targetLanguage] = value, Getter = () => _namespace[_targetLanguage], Description = "Namespace for the generated service model"},
                new Option {Key = "UsingDirectives", Setter = value => _usingDirectives[_targetLanguage] = value, Getter = () => _usingDirectives[_targetLanguage], Description = "using directives (semicolon-separated) for the generated sevice model"},
                new Option {Key = "Aliases", Setter = value => _aliases[_targetLanguage] = value, Getter = () => _aliases[_targetLanguage], Description = "Type aliases (semicolon-separated) in SwaggerType=AliasType format"},
                new Option {Key = "Fixups", Setter = value => _fixups = value, Getter = () => _fixups, Description = "Fixups (semicolon-separated) in Verb:Route=RequestDtoName format"},
                new Option {Key = "Enums", Setter = value => _enums = value, Getter = () => _enums, Description = "Enum overrides (semicolon-separated) in EnumTypeName=fieldName.Value1,...,ValueN format"},
            };

            _usageMessage =
                $"Clones an AQTS configuration (using TimeSeriesSupport) to an NG system (using public APIs)"
                + $"\n\nusage: {Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)} [-option=value] ... [commands ...]"
                + $"\n\nSupported -option=value settings (/option=value works too):\n\n  -{string.Join("\n  -", options.Select(o => o.UsageText()))}"
                ;

            foreach (var arg in args)
            {
                var match = ArgRegex.Match(arg);

                if (!match.Success)
                {
                    throw new ExpectedException($"Unknown argument: {arg}\n\n{_usageMessage}");
                }

                var key = match.Groups["key"].Value.ToLower();
                var value = match.Groups["value"].Value;

                var option =
                    options.FirstOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));

                if (option == null)
                {
                    throw new ExpectedException($"Unknown -option=value: {arg}\n\n{_usageMessage}");
                }

                option.Setter(value);
            }
        }

        private void Run()
        {
            TypeMapper.Language = _targetLanguage;

            var jsonText = LoadStringFromUrl(_url);

            var parser = new Parser
            {
                EnumOverrides = _enums
                    .Split(ItemSeparators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => EnumRegex.Match(s))
                    .Where(m => m.Success)
                    .ToDictionary(
                        m => $"{m.Groups["fieldName"].Value.Trim()}.{string.Join(",", m.Groups["valueList"].Value.Split(ListSeparators, StringSplitOptions.RemoveEmptyEntries))}",
                        m => new Enum(
                            new Property {Name = m.Groups["enumName"].Value.Trim()},
                            new Property {Name = m.Groups["enumName"].Value.Trim()},
                            m.Groups["valueList"].Value.Split(ListSeparators, StringSplitOptions.RemoveEmptyEntries)))
            };

            var api = parser.Parse(jsonText, _url);

            var generator = CreateCodeGenerator(api);

            _log.Info($"{api.Title} ({api.Version}) has {api.Paths.SelectMany(p => p.Operations).Count()} operations, {api.Definitions.Count} definitions and {api.Enums.Count} enumerations");

            var code = generator.GenerateServiceModel();
            var filename = _filename[_targetLanguage];

            _log.Info($"Writing code to {filename} ...");

            File.WriteAllText(filename, code);
        }

        private static readonly char[] ItemSeparators = { ';' };
        private static readonly char[] ListSeparators = { ',', ' ' };
        private static readonly Regex AliasRegex = new Regex(@"^\s*(?<swaggerType>[^= ]+)\s*=\s*(?<aliasType>[^ ]+)\s*$", RegexOptions.Compiled);
        private static readonly Regex FixupRegex = new Regex(@"^\s*(?<methodRoute>[^= ]+)\s*=\s*(?<requestDtoName>[^ ]+)\s*$", RegexOptions.Compiled);
        private static readonly Regex EnumRegex = new Regex(@"^\s*(?<enumName>[^= ]+)\s*=\s*(?<fieldName>[^. ]+)\s*\.\s*(?<valueList>[^ ]+)\s*$", RegexOptions.Compiled);

        private string LoadStringFromUrl(string url)
        {
            var uri = new Uri(url);

            _log.Info($"Fetching {uri} ...");

            using (var client = new WebClient())
            {
                return client.DownloadString(uri);
            }
        }

        private CodeGeneratorBase CreateCodeGenerator(Api api)
        {
            var generator = _targetLanguage == TargetLanguage.CSharp
                ? (CodeGeneratorBase)new CSharpCodeGenerator()
                : new JavaCodeGenerator();

            generator.Api = api;
            generator.Filename = _filename[_targetLanguage];
            generator.Namespace = _namespace[_targetLanguage];

            generator.UsingDirectives = _usingDirectives[_targetLanguage]
                .Split(ItemSeparators, StringSplitOptions.RemoveEmptyEntries);

            generator.Aliases = _aliases[_targetLanguage]
                .Split(ItemSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => AliasRegex.Match(s))
                .Where(m => m.Success)
                .ToDictionary(m => m.Groups["swaggerType"].Value.Trim(), m => m.Groups["aliasType"].Value.Trim());

            generator.RequestDtoFixups = _fixups
                .Split(ItemSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => FixupRegex.Match(s))
                .Where(m => m.Success)
                .ToDictionary(m => m.Groups["methodRoute"].Value.Trim(), m => m.Groups["requestDtoName"].Value.Trim());

            return generator;
        }
    }
}
