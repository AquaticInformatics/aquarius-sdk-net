using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Humanizer;
using ServiceStack;
using log4net;
using ServiceStack.Text;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Parser
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Dictionary<string,Enum> EnumOverrides { get; set; }

        public Api Parse(string jsonText, string baseUrl)
        {
            var swagger = JsonObject.Parse(jsonText);

            var swaggerVersion = swagger["swagger"];

            if (swaggerVersion != "2.0")
                throw new ExpectedException($"{baseUrl} is not a Swagger 2.0 JSON file.");

            var info = swagger.Object("info");
            var version = info["version"];
            var title = info["title"];

            var definitions = ParseDefinitions(swagger.Object("definitions"));
            var paths = ParsePaths(swagger.Object("paths")).ToList();
            var enums = ParseEnums(definitions, paths);

            return new Api
            {
                Title = title,
                Version = version,
                BaseUrl = baseUrl,
                Definitions = definitions,
                Enums = enums,
                Paths = paths
            };
        }

        private List<Definition> ParseDefinitions(JsonObject json)
        {
            var definitions = json
                .Select(kvp => ParseDefinition(kvp.Key, kvp.Value))
                .ToList();

            return definitions
                .OrderBy(d => d.Name)
                .ToList();
        }

        private Definition ParseDefinition(string name, string jsonText)
        {
            var definition = jsonText.FromJson<Definition>();

            if (string.IsNullOrEmpty(definition.Name))
                definition.Name = name;

            var properties = JsonObject.Parse(jsonText).Object("properties");

            if (properties != null)
            {
                definition.Properties = properties
                    .Select(kvp => ParseProperty(kvp.Key, kvp.Value, definition))
                    .ToArray();
            }

            return definition;
        }

        private Property ParseProperty(string name, string jsonText, Definition owner)
        {
            var property = jsonText.FromJson<Property>();

            ParseRef(property, jsonText);

            ParseRef(property.Items, JsonObject.Parse(jsonText).Object("items"));

            if (property.Type == Type.Unknown)
                throw new ArgumentException($"Can't parse property type for name='{name}' from json={jsonText} , Owner={owner.ToJson()}");

            if (string.IsNullOrEmpty(property.Name))
                property.Name = name;

            property.Owner = owner;

            return property;
        }

        private static void ParseRef(ITypedItem item, string jsonText)
        {
            ParseRef(item, JsonObject.Parse(jsonText));
        }

        private static void ParseRef(ITypedItem item, JsonObject json)
        {
            if (item == null || json == null)
                return;

            var reference = json["$ref"];

            if (reference == null)
                return;

            var match = DefinitionsReferenceRegex.Match(reference);

            if (!match.Success)
                return;

            item.Type = Type.Ref;
            item.Ref = match.Groups["name"].Value;
        }

        private static readonly Regex DefinitionsReferenceRegex = new Regex(@"^\#/definitions/(?<name>\w+)$");

        private List<Enum> ParseEnums(List<Definition> definitions, List<Path> paths)
        {
            // The original Java enum class backing the enumerated values is not exposed in the Swagger spec.
            // So try to infer a concise set of enum definitions.

            // Pass 1: By default, these enums have EnumTypeName = property.Name + "Type"
            var allEnums = definitions
                .SelectMany(definition => definition.Properties
                    .Where(IsEnumRequiringNormalization)
                    .Select(property => new Enum(definition, property, property.Enum)))
                .ToList();

            allEnums.AddRange(paths
                .SelectMany(path => path.Operations.Values.SelectMany(operation =>
                    operation.Parameters.Where(IsEnumRequiringNormalization)
                        .Select(parameter => new Enum(new Property {Name = operation.OperationId}, parameter, parameter.Enum)))));

            allEnums.AddRange(paths
                .SelectMany(p => p.Operations.Values.SelectMany(o =>
                {
                    var schema = o.SuccessResponse()?.Schema;

                    if (schema == null ||!IsEnumRequiringNormalization(schema))
                        return new Enum[0];

                    if (string.IsNullOrEmpty(schema.Name))
                        schema.Name = o.OperationId;

                    return new [] {new Enum(new Property {Name = o.OperationId}, schema, schema.Enum)};
                })));

            // Pass 2: Consolidate any enum overrides
            var enums = ReplaceEnumOverrides(allEnums);

            // Pass 3: Remove pure-identical duplicates
            enums = RemovePureEnumDuplicates(enums);

            // Pass 4: Resolve any remaining enum type name collisions
            enums = ResolveEnumTypeNameCollisions(enums);

            return enums
                .OrderBy(p => p.EnumTypeName)
                .ToList();
        }

        private static bool IsEnumRequiringNormalization(ITypedItem item)
        {
            return item.Type == Type.String && item.Enum != null && item.Enum.Any();
        }

        private List<Enum> ReplaceEnumOverrides(List<Enum> enums)
        {
            foreach (var enum1 in enums)
            {
                var overrideKey = $"{enum1.Source.Name}.{string.Join(",", enum1.Values)}";

                Enum overrideEnum;
                if (!EnumOverrides.TryGetValue(overrideKey, out overrideEnum))
                    continue;

                if (!AreEnumsIdentical(enum1, overrideEnum))
                    continue;

                enum1.MakeEnumTypeName(overrideEnum.EnumTypeName);
            }

            return enums;
        }

        private static List<Enum> RemovePureEnumDuplicates(List<Enum> allEnums)
        {
            var enums = new List<Enum>();

            foreach (var enum1 in allEnums)
            {
                var enumsWithSameTypeName = allEnums
                    .Where(otherEnum => otherEnum.EnumTypeName == enum1.EnumTypeName)
                    .ToList();

                if (enumsWithSameTypeName.All(enum2 => AreEnumsIdentical(enum1, enum2)))
                {
                    if (enums.All(otherEnum => otherEnum.EnumTypeName != enum1.EnumTypeName))
                    {
                        enums.Add(enum1);
                    }

                    continue;
                }

                enums.Add(enum1);
            }

            return enums;
        }

        private static List<Enum> ResolveEnumTypeNameCollisions(List<Enum> enums)
        {
            foreach (var masterEnum in enums)
            {
                var enumsWithSameTypeName = enums
                    .Where(otherEnum => otherEnum.EnumTypeName == masterEnum.EnumTypeName)
                    .ToList();

                if (enumsWithSameTypeName.Count < 2)
                    continue;

                foreach (var enumProperty in enumsWithSameTypeName)
                {
                    enumProperty.MakeDistinctEnumTypeName();
                    Log.Info($"Distinct enum {enumProperty.EnumTypeName} made from {EnumSignature(enumProperty)}");
                }
            }

            return enums;
        }

        private static string EnumSignature(Enum enum1)
        {
            return $"'{enum1.Owner.Name}.{enum1.Source.Name}' [{string.Join(", ", enum1.Values)}]";
        }

        private static bool AreEnumsIdentical(Enum enum1, Enum enum2)
        {
            return enum1.Values.All(v1 => enum2.Values.Any(v2 => v2 == v1));
        }
        private IEnumerable<Path> ParsePaths(JsonObject json)
        {
            return json.Select(pathKvp => new Path
            {
                Route = pathKvp.Key,
                Operations = JsonObject.Parse(pathKvp.Value).Where(operationKvp => SupportedMethods.Contains(operationKvp.Key))
                    .ToDictionary(
                        operationKvp => operationKvp.Key.ToUpperInvariant(),
                        operationKvp => ParseOperation(pathKvp.Key, operationKvp.Key, operationKvp.Value))
            })
            .OrderBy(p => p.Route);
        }

        private static readonly HashSet<string> SupportedMethods =
            new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
            {
                HttpMethods.Get,
                HttpMethods.Post,
                HttpMethods.Put,
                HttpMethods.Delete
            };

        private Operation ParseOperation(string route, string method, string jsonText)
        {
            var operation = jsonText.FromJson<Operation>();
            operation.Route = route;
            operation.Method = method.ToUpperInvariant();

            var json = JsonObject.Parse(jsonText);

            var parameters = json.ArrayObjects("parameters");
            for(var i = 0; i < parameters.Count; ++i)
            {
                ParseRef(operation.Parameters[i], parameters[i]);
                ParseSchema(operation.Parameters[i].Schema, parameters[i]?.Object("schema"));
            }

            var responses = json.Object("responses");

            foreach (var responseKvp in responses)
            {
                var statusCode = responseKvp.Key;
                var responseJsonText = responseKvp.Value;

                AdjustResponse(operation.Responses[statusCode], responseJsonText);
            }

            NormalizeOperation(operation);

            return operation;
        }

        private void ParseSchema(OperationSchema schema, JsonObject json)
        {
            if (schema == null || json == null)
                return;

            ParseRef(schema.Items, json.Object("items"));
            ParseRef(schema, json);

        }

        private void NormalizeOperation(Operation operation)
        {
            operation.OperationId = GetOperationIdWithoutTrailingNumbers(operation);

            var operationId = operation.OperationId;

            if (operationId.Equals("sparsePut", StringComparison.InvariantCultureIgnoreCase))
            {
                operation.OperationId = $"PutSparse{InferOperationClass(operation)}";
                return;
            }

            var match = DomainObjectRegex.Match(operationId);

            if (match.Success)
            {
                operationId = operation.OperationId.Replace(match.Value, InferOperationClass(operation));
            }

            if (!operationId.StartsWith(operation.Method, StringComparison.InvariantCultureIgnoreCase))
            {
                operationId = operation.Method.ToPascalCase() + operationId.ToPascalCase();
            }

            operation.OperationId = operationId;
        }

        private string GetOperationIdWithoutTrailingNumbers(Operation operation)
        {
            return operation.OperationId.Split('_')[0];
        }

        private static readonly Regex DomainObjectRegex = new Regex(@"domainObjects?", RegexOptions.CultureInvariant|RegexOptions.IgnoreCase);

        private static string InferOperationClass(Operation operation)
        {
            var components = operation.Route.Split(RouteSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (VersionComponentRegex.IsMatch(components.First()))
                components.RemoveAt(0);

            var words = new List<string>();

            var allTags = string.Join(" ", operation.Tags)
                .Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.ToTitleCase())
                .ToList();

            var successResponseTypeName = string.Empty;
            var successResponse = operation.SuccessResponse();

            if (successResponse?.Schema != null)
            {
                successResponseTypeName = TypeMapper.Map(successResponse.Schema);
            }

            var shouldSingularizeLastWord = operation.Method == "POST" && !TemplateComponentRegex.IsMatch(components.Last());

            foreach (var component in components)
            {
                if (TemplateComponentRegex.IsMatch(component))
                {
                    if (!words.Any())
                        throw new ExpectedException($"Unexpected template component in Operation={operation.ToJson()}");

                    SingularizeLastWord(words);
                    continue;
                }

                if (component.Equals(successResponseTypeName, StringComparison.InvariantCultureIgnoreCase))
                {
                    words.Add(successResponseTypeName);
                    continue;
                }

                var lowerComponent = component.ToLowerInvariant();

                var tagsAdded = 0;
                foreach (var tag in allTags)
                {
                    if (lowerComponent.Contains(tag.ToLowerInvariant()))
                    {
                        if (!words.Any(w => w.StartsWith(tag, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            words.Add(tag);
                            ++tagsAdded;
                        }
                    }
                }

                if (tagsAdded > 0)
                    continue;

                if (words.Contains(lowerComponent))
                    continue;

                words.Add(component.ToPascalCase());
            }

            if (shouldSingularizeLastWord)
                SingularizeLastWord(words);

            if (words.Any())
                return string.Join("", words);

            throw new ExpectedException($"Don't know how infer an operation name for Operation={operation.ToJson()}");
        }

        private static void SingularizeLastWord(List<string> words)
        {
            var lastWordSingular = words.Last().Singularize(inputIsKnownToBePlural: false);
            words.RemoveAt(words.Count - 1);
            words.Add(lastWordSingular);
        }

        private static readonly char[] WordSeparators = { ' ' };
        private static readonly char[] RouteSeparators = { '/' };

        private static readonly Regex VersionComponentRegex = new Regex(@"^[vV]\d+$");
        private static readonly Regex TemplateComponentRegex = new Regex(@"^{\w+}$", RegexOptions.CultureInvariant|RegexOptions.IgnoreCase);

        private void AdjustResponse(OperationResponse response, string jsonText)
        {
            var json = JsonObject.Parse(jsonText);

            var schema = json.Object("schema");

            if (schema == null)
                return;

            ParseRef(response.Schema, schema);
            ParseRef(response.Schema.Items, schema.Object("items"));
        }
    }
}
