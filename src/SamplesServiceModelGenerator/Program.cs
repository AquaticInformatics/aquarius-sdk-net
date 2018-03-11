using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using SamplesServiceModelGenerator.CodeGenerators;
using SamplesServiceModelGenerator.Swagger;
using log4net;
using log4net.Config;
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
            var entryAssembly = Assembly.GetEntryAssembly();
            var logRepository = LogManager.GetRepository(entryAssembly);
            XmlConfigurator.Configure(logRepository, new FileInfo(Path.Combine(Path.GetDirectoryName(entryAssembly.Location), "log4net.config")));

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
            {TargetLanguage.CSharp, string.Join(";",
                "System",
                "System.Collections.Generic",
                "ServiceStack",
                "NodaTime",
                "Aquarius.TimeSeries.Client")},
            {TargetLanguage.Java, string.Join(";",
                "java.time.*",
                "java.util.*",
                "com.google.gson.annotations.SerializedName",
                "com.google.gson.reflect.TypeToken",
                "net.servicestack.client.*",
                "com.aquaticinformatics.aquarius.sdk.AquariusServerVersion")},
        };

        private Dictionary<TargetLanguage, string> _filename = new Dictionary<TargetLanguage, string>
        {
            {TargetLanguage.CSharp, "ServiceModel.cs"},
            {TargetLanguage.Java, "ServiceModel.java"},
        };

        private Dictionary<TargetLanguage, string> _aliases = new Dictionary<TargetLanguage, string>
        {
            {TargetLanguage.CSharp, string.Join(";",
                "DomainDateTime=Instant?",
                "DomainDateTimeRange=TimeRange")},
            {TargetLanguage.Java, string.Join(";",
                "DomainDateTime=Instant",
                "DomainDateTimeRange=Interval")},
        };

        private string _enums = string.Join(";",
            "ActivityType=type.SAMPLE_INTEGRATED_VERTICAL_PROFILE,SAMPLE_ROUTINE,QC_SAMPLE_REPLICATE,QC_TRIP_BLANK,FIELD_SURVEY,NONE",
            "AnalyticalGroupType=type.KNOWN,UNKNOWN",
            "ImportItemStatusType=status.ERROR,NEW,UPDATE,EXPECTED,SKIPPED",
            "SpecimenViewStatusType=status.REQUESTED,RECEIVED_SOME,RECEIVED_ALL");

        private string _fixups = string.Join(";",
            // These camelcase fixups are in anticipation of the 2018.4 deployment, after which no more fixups should be needed.
            "POST:/v1/fieldvisits/{id}/activityfromplannedactivity=PostFieldVisitActivityFromPlannedActivity",
            "POST:/v1/fieldvisits/{id}/activitywithtemplate=PostFieldVisitActivityWithTemplate",
            "GET:/v1/samplinglocations/{id}/canedit=GetSamplingLocationCanEdit",
            "POST:/v1/services/import/samplinglocations/dryrun=PostImportSamplingLocationsDryRun",
            "POST:/v1/services/import/observedproperties/dryrun=PostImportObservedPropertiesDryRun",
            "POST:/v1/services/import/labanalysismethods/dryrun=PostImportAnalysisMethodsDryRun",
            "POST:/v1/services/import/observations/dryrun=PostImportObservationsDryRun");

        private Dictionary<TargetLanguage, string> _obsoleteDtos = new Dictionary<TargetLanguage, string>
        {
            {
                TargetLanguage.CSharp, string.Join(";",
                    // These are a result of the manual fixups above.
                    "PostActivityFromPlannedActivity:PostFieldVisitActivityFromPlannedActivity",
                    "PostActivityWithTemplate:PostFieldVisitActivityWithTemplate",
                    "GetCanUserEditSamplingLocationData:GetSamplingLocationCanEdit",
                    "PostImportSamplingLocationsDryrun:PostImportSamplingLocationsDryRun",
                    "PostImportObservedPropertiesDryrun:PostImportObservedPropertiesDryRun",
                    "PostImportAnalysisMethodsDryrun:PostImportAnalysisMethodsDryRun",
                    "PostImportObservationsDryrun:PostImportObservationsDryRun",
                    // These obsolete DTOs come from the cleanup contained within the 2018.03 deployment
                    "PutSparseAccessGroup:PutAccessGroup",
                    "DeleteAccessGroupById:DeleteAccessGroup",
                    "PutSparseActivity:PutActivity",
                    "DeleteActivityById:DeleteActivity",
                    "PostReplicateActivity:PostActivityReplicate",
                    "PutSparseActivityTemplate:PutActivityTemplate",
                    "DeleteActivityTemplateById:DeleteActivityTemplate",
                    "PutSparseAnalyticalGroup:PutAnalyticalGroup",
                    "DeleteAnalyticalGroupById:DeleteAnalyticalGroup",
                    "GetAttachmentContent:GetAttachmentContents",
                    "PutSparseCollectionMethod:PutCollectionMethod",
                    "DeleteCollectionMethodById:DeleteCollectionMethod",
                    "PutSparseFieldTrip:PutFieldTrip",
                    "DeleteFieldTripById:DeleteFieldTrip",
                    "PutSparseFieldVisit:PutFieldVisit",
                    "DeleteFieldVisitById:DeleteFieldVisit",
                    "PutSparseLabAnalysisMethod:PutLabAnalysisMethod",
                    "DeleteLabAnalysisMethodById:DeleteLabAnalysisMethod",
                    "PutSparseLaboratory:PutLaboratory",
                    "DeleteLaboratoryById:DeleteLaboratory",
                    "PutSparseLabReport:PutLabReport",
                    "DeleteLabReportById:DeleteLabReport",
                    "PutSparseObservation:PutObservation",
                    "DeleteObservationById:DeleteObservation",
                    "PutSparseObservedProperty:PutObservedProperty",
                    "DeleteObservedPropertyById:DeleteObservedProperty",
                    "PutSparseProject:PutProject",
                    "DeleteProjectById:DeleteProject",
                    "PutSparseSamplingLocationGroup:PutSamplingLocationGroup",
                    "DeleteSamplingLocationGroupById:DeleteSamplingLocationGroup",
                    "PutSparseSamplingLocation:PutSamplingLocation",
                    "DeleteSamplingLocationById:DeleteSamplingLocation",
                    "GetSummary:GetSamplingLocationSummary",
                    "PutSparseShippingContainer:PutShippingContainer",
                    "DeleteShippingContainerById:DeleteShippingContainer",
                    "PutSparseSpecimen:PutSpecimen",
                    "DeleteSpecimenById:DeleteSpecimen",
                    "PutSparseSpreadsheetTemplate:PutSpreadsheetTemplate",
                    "DeleteSpreadsheetTemplateById:DeleteSpreadsheetTemplate",
                    "PutSparseStandard:PutStandard",
                    "PutSparseTag:PutTag",
                    "DeleteTagById:DeleteTag",
                    "PutSparseTaxon:PutTaxon",
                    "DeleteTaxonById:DeleteTaxon",
                    "PutSparseUnitGroup:PutUnitGroup",
                    "DeleteUnitGroupById:DeleteUnitGroup",
                    "GetUnitGroupsWithUnits:GetUnitGroupWithUnit",
                    "PutSparseUnitGroupWithUnits:PutUnitGroupWithUnit",
                    "DeleteUnitGroupWithUnitsById:DeleteUnitGroupWithUnit",
                    "PutSparseUnit:PutUnit",
                    "DeleteUnitById:DeleteUnit",
                    "Put:PutUser",
                    "DeleteUserById:DeleteUser")
            },
            {TargetLanguage.Java, "" },
        };

        private void ParseArgs(string[] args)
        {
            var resolvedArgs = args
                .SelectMany(ResolveOptionsFromFile)
                .ToArray();

            var options = new[]
            {
                new Option {Key = "Language", Setter = value => _targetLanguage = (TargetLanguage)System.Enum.Parse(typeof(TargetLanguage), value, true), Getter = () => _targetLanguage.ToString(), Description = $"Language for the generated service model code. One of: {string.Join(", ", System.Enum.GetNames(typeof(TargetLanguage)))}. This option should be set before setting any -Namespace, -UsingDirectives, or -Aliases options."},
                new Option {Key = "URL", Setter = value => _url = value, Getter = () => _url, Description = "URL for Swagger 2.0 JSON"},
                new Option {Key = "Filename", Setter = value => _filename[_targetLanguage] = value, Getter = () => _filename[_targetLanguage], Description = "Filename for the generated service model code"},
                new Option {Key = "Namespace", Setter = value => _namespace[_targetLanguage] = value, Getter = () => _namespace[_targetLanguage], Description = "Namespace for the generated service model"},
                new Option {Key = "UsingDirectives", Setter = value => _usingDirectives[_targetLanguage] = value, Getter = () => _usingDirectives[_targetLanguage], Description = "using directives (semicolon-separated) for the generated sevice model"},
                new Option {Key = "Aliases", Setter = value => _aliases[_targetLanguage] = value, Getter = () => _aliases[_targetLanguage], Description = "Type aliases (semicolon-separated) in SwaggerType=AliasType format"},
                new Option {Key = "Obsolete", Setter = value => _obsoleteDtos[_targetLanguage] = value, Getter = () => _obsoleteDtos[_targetLanguage], Description = "Obsolete DTOs (semicolon-separated) in ObsoleteDtoName=PreferredDtoName format"},
                new Option {Key = "Fixups", Setter = value => _fixups = value, Getter = () => _fixups, Description = "Fixups (semicolon-separated) in Verb:Route=RequestDtoName format"},
                new Option {Key = "Enums", Setter = value => _enums = value, Getter = () => _enums, Description = "Enum overrides (semicolon-separated) in EnumTypeName=fieldName.Value1,...,ValueN format"},
            };

            _usageMessage =
                $"Generates the Samples SDK service model DTOs from a Swagger 2.0 JSON spec."
                + $"\n"
                + $"\nusage: {Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)} [-option=value] [@optionsFile] ... [commands ...]"
                + $"\n"
                + $"\nSupported -option=value settings (/option=value works too):\n\n  -{string.Join("\n  -", options.Select(o => o.UsageText()))}"
                + $"\n"
                + $"\nUse the @optionsFile syntax to read more options from a file."
                + $"\n"
                + $"\n  Each line in the file is treated as a command line option."
                + $"\n  Blank lines and leading/trailing whitespace is ignored."
                + $"\n  Comment lines begin with a # or // marker."
                ;

            foreach (var arg in resolvedArgs)
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

        private static IEnumerable<string> ResolveOptionsFromFile(string arg)
        {
            if (!arg.StartsWith("@"))
                return new[] { arg };

            var path = arg.Substring(1);

            if (!File.Exists(path))
                throw new ExpectedException($"Options file '{path}' does not exist.");

            return File.ReadAllLines(path)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => s.Trim())
                .Where(s => !s.StartsWith("#") && !s.StartsWith("//"));
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
        private static readonly Regex ObsoleteRegex = new Regex(@"^\s*(?<obsoleteDtoName>[^: ]+)\s*:\s*(?<preferredDtoName>[^ ]+)\s*$", RegexOptions.Compiled);

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

            generator.ObsoleteDtos = _obsoleteDtos[_targetLanguage]
                .Split(ItemSeparators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => ObsoleteRegex.Match(s))
                    .Where(m => m.Success)
                    .ToDictionary(m => m.Groups["obsoleteDtoName"].Value.Trim(), m => m.Groups["preferredDtoName"].Value.Trim());

            return generator;
        }
    }
}
