using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ServiceStack;
using SamplesServiceModelGenerator.Swagger;
using Type = SamplesServiceModelGenerator.Swagger.Type;

namespace SamplesServiceModelGenerator.CodeGenerators
{
    public abstract class CodeGeneratorBase
    {
        protected CodeGeneratorBase()
        {
            UsingDirectives = new string[0];
            Aliases = new Dictionary<string, string>();
        }

        public DateTime GenerationTime { get; set; } = DateTime.Now;
        public Api Api { get; set; }
        public string Filename { get; set; }
        public string Namespace { get; set; }
        public string[] UsingDirectives { get; set; }
        public Dictionary<string, string> Aliases { get; set; }
        public Dictionary<string, string> RequestDtoFixups { get; set; }
        public Dictionary<string, string> ObsoleteDtos { get; set; }

        protected abstract string BeginFile();
        protected abstract string EndFile();
        protected abstract string BeginNamespace();
        protected abstract string EndNamespace();
        protected abstract string AllRequestDtos();
        protected abstract string AllPocos();
        protected abstract string AllEnums();

        public string GenerateServiceModel()
        {
            var builder = new StringBuilder();

            builder
                .Append(BeginFile())
                .Append(BeginNamespace())
                .AppendLine()
                .Append(AllRequestDtos())
                .AppendLine()
                .Append(AllPocos())
                .AppendLine()
                .Append(AllEnums())
                .Append(EndNamespace())
                .Append(EndFile());

            return builder.ToString();
        }

        protected string ResolveTypeName(ITypedItem item)
        {
            var typeName = TypeMapper.Map(item);

            return Aliases.TryGetValue(typeName, out var aliasedType)
                ? aliasedType
                : typeName;
        }

        protected string ResolveName(ITypedItem item)
        {
            var name = item.Name;

            return name.Replace('-', '_').ToPascalCase();
        }

        protected static string GetResponseBaseType(Operation operation)
        {
            var response = operation.SuccessResponse();

            if (response?.Schema == null)
                return null;

            var schema = response.Schema;

            return TypeMapper.Map(schema);
        }

        protected string GetPaginatedRequestType(Operation operation, List<OperationParameter> parameters)
        {
            if (!parameters.Any(p => p.Type == Type.String &&
                                     p.Name.Equals("Cursor", StringComparison.InvariantCultureIgnoreCase)))
                return null;

            var responseBaseType = GetResponseBaseType(operation);

            if (string.IsNullOrEmpty(responseBaseType))
                return null;

            var definition =
                Api.Definitions.SingleOrDefault(
                    d => d.Name.Equals(responseBaseType, StringComparison.InvariantCultureIgnoreCase));

            if (definition == null)
                return null;

            return GetPaginatedResponseType(definition);
        }

        protected string GetPaginatedResponseType(Definition definition)
        {
            var totalCount = definition.Properties.FirstOrDefault(p => p.Type == Type.Integer && p.Name.Equals("TotalCount", StringComparison.InvariantCultureIgnoreCase));
            var cursor = definition.Properties.FirstOrDefault(p => p.Type == Type.String && p.Name.Equals("Cursor", StringComparison.InvariantCultureIgnoreCase));
            var domainObjects = definition.Properties.FirstOrDefault(p => p.Type == Type.Array && p.Name.Equals("DomainObjects", StringComparison.InvariantCultureIgnoreCase));

            if (totalCount == null || cursor == null || domainObjects == null)
                return null;

            return domainObjects.ArrayTypeName();
        }

        protected string GetOperationName(Operation operation)
        {
            var operationName = GetUnversionedOperationName(operation);

            if (IsOperationV1Endpoint(operation))
            {
                return operationName;
            }

            return operationName + GetOperationRouteVersion(operation).ToPascalCase();
        }

        private string GetUnversionedOperationName(Operation operation)
        {
            var fixupKey = $"{operation.Method}:{operation.Route}";
            var operationId = operation.OperationId.ToPascalCase();
            var operationName = RequestDtoFixups.TryGetValue(fixupKey, out var fixupName)
                ? fixupName
                : operationId;
            return operationName;
        }

        private static bool IsOperationV1Endpoint(Operation operation)
        {
            return GetOperationRouteVersion(operation) == "v1";
        }

        private static string GetOperationRouteVersion(Operation operation)
        {
            var match = VersionedRouteRegex.Match(operation.Route);

            if (!match.Success)
            {
                throw new ArgumentException($"Could not extract version from {operation.Route}");
            }

            return match.Groups["version"].Value;
        }

        private static readonly Regex VersionedRouteRegex = new Regex(@"^/(?<version>v\d+)/");

        protected IEnumerable<OperationParameter> GetOperationParameters(Operation operation)
        {
            var parameters = new List<OperationParameter>();

            foreach (var parameter in operation.Parameters)
            {
                if (parameter.Type == Type.Unknown && parameter.In == ParameterType.Body && parameter.Schema != null)
                {
                    if (parameter.Schema.Type == Type.Array)
                    {
                        // TODO: Can we add support for anonymous lists as a request DTO?
                        // See petstore: `POST /user/createWithArray` where the request body is an anonymous list of User objects
                        // [Route("/some/route", "VERB"]
                        // public class MyOperationName: List<T>, IReturn<TResponse> or IReturnVoid
                        // {
                        //     public MyOperationName(IEnumerable<T> items):base(items){}
                        // }
                        if (operation.Parameters.Length == 1)
                        {
                            return new OperationParameter[0];
                        } 
                        else
                        {
                            // If body is not the only parameter allow parameter parsing to continue on
                            // Example case where this is needed: 
                            //   POST /v1/observedproperties/{id}/categoricalvalues
                            //   Body: Array<CategoricalValues>
                            continue;
                        }
                    }

                    var typeName = TypeMapper.Map(parameter.Schema);

                    var definition = Api.Definitions.SingleOrDefault(d => d.Name == typeName);

                    if (definition == null)
                        throw new ExpectedException($"Can't find definition for typeName='{typeName}'");

                    foreach (var property in definition.Properties)
                    {
                        if (IsParameterMapped(operation, parameters, property))
                            continue;

                        parameters.Add(Map(property));
                    }
                }
                else if (!IsParameterMapped(operation, parameters, parameter))
                {
                    parameters.Add(parameter);
                }
            }

            return parameters;
        }

        private static bool IsParameterMapped(Operation operation, List<OperationParameter> parameters, ITypedItem item)
        {
            var parameter = parameters.SingleOrDefault(p => p.Name == item.Name);

            if (parameter != null)
            {
                var mappedTypeName = TypeMapper.Map(parameter);
                var itemTypeName = TypeMapper.Map(item);

                if (mappedTypeName != itemTypeName)
                    throw new ExpectedException($"{operation.Route} has conflicting parameter types for Name='{parameter.Name}' Type1={mappedTypeName} Type2={itemTypeName}");
            }

            return parameter != null;
        }

        private static OperationParameter Map(Swagger.Property property)
        {
            if (property == null)
                return null;

            if (property.Type == Type.Unknown)
                throw new ArgumentException($"Unknown property type for {property.ToJson()}");

            return new OperationParameter
            {
                Name = property.Name,
                Type = property.Type,
                Format = property.Format,
                Ref = property.Ref,
                Items = Map(property.Items),
                EnumTypeName = property.EnumTypeName,
                Enum = property.Enum,
            };
        }
    }
}
