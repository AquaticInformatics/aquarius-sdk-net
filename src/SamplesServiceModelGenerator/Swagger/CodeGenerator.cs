using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack;

namespace SamplesServiceModelGenerator.Swagger
{
    public class CodeGenerator
    {
        public CodeGenerator()
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

        public string GenerateServiceModel()
        {
            var builder = new StringBuilder();

            builder
                .Append($"// Date: {GenerationTime:O}\r\n")
                .Append($"// Base URL: {Api.BaseUrl}\r\n")
                .Append($"// Source: {Api.Title} ({Api.Version})\r\n")
                .AppendLine()
                .Append(string.Join("", UsingDirectives.Select(name => $"using {name};\r\n")))
                .Append($"// ReSharper disable InconsistentNaming\r\n")
                .AppendLine()
                .Append($"// ReSharper disable once CheckNamespace\r\n")
                .Append($"namespace {Namespace}\r\n")
                .Append("{\r\n")
                .Append($"    public static class Current\r\n")
                .Append($"    {{\r\n")
                .Append($"        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create(\"{Api.Version}\");\r\n")
                .Append($"    }}\r\n")
                .AppendLine()
                .Append($"{string.Join("\r\n", Api.Paths.Select(CreateRequestDtos))}")
                .AppendLine()
                .Append($"{string.Join("\r\n", Api.Definitions.Select(CreatePoco))}")
                .AppendLine()
                .Append($"{string.Join("\r\n", Api.Enums.Select(CreateEnum))}")
                .Append("}\r\n");

            return builder.ToString();
        }

        private string CreatePoco(Definition definition)
        {
            var builder = new StringBuilder();

            if (Aliases.ContainsKey(definition.Name))
                return string.Empty;

            builder.Append($"    public class {definition.Name}");

            if (definition.Simple)
            {
                builder.Append($" : {TypeMapper.Map(definition)}");
            }
            else
            {
                builder.Append(PaginatedResponseConstraint(GetPaginatedResponseType(definition)));
            }

            builder.Append("\r\n    {\r\n");

            var arrayProperties = definition.Properties.Where(p => p.Type == Type.Array).ToList();

            if (arrayProperties.Any())
            {
                builder
                    .Append($"        public {definition.Name}()\r\n")
                    .Append("        {\r\n");

                foreach (var property in arrayProperties)
                {
                    builder.Append($"            {ResolveName(property)} = new {ResolveTypeName(property)}();\r\n");
                }

                builder.Append("        }\r\n\r\n");
            }

            foreach (var property in definition.Properties)
            {
                builder.Append(
                    $"        public {ResolveTypeName(property)} {ResolveName(property)} {{ get; set; }}\r\n");
            }

            builder.Append("    }\r\n");

            return builder.ToString();
        }

        private string ResolveTypeName(ITypedItem item)
        {
            var typeName = TypeMapper.Map(item);

            string aliasedType;
            return Aliases.TryGetValue(typeName, out aliasedType)
                ? aliasedType
                : typeName;
        }

        private string ResolveName(ITypedItem item)
        {
            var name = item.Name;

            return name.Replace('-', '_').ToPascalCase();
        }

        private string CreateEnum(Enum enum1)
        {
            var builder = new StringBuilder();

            builder
                .Append($"    public enum {enum1.EnumTypeName}\r\n")
                .Append("    {\r\n")
                .Append($"        {string.Join(",\r\n        ", enum1.Values)}\r\n")
                .Append("    }\r\n");

            return builder.ToString();
        }

        private string CreateRequestDtos(Path path)
        {
            return string.Join("\r\n", path.Operations.Select(kvp => CreateRequestDto(kvp.Value)));
        }

        private string CreateRequestDto(Operation operation)
        {
            var builder = new StringBuilder();

            var responseDtoType = GetResponseDtoType(operation);
            var operationName = GetOperationName(operation);
            var parameters = GetOperationParameters(operation).ToList();

            var paginatedRequestType = GetPaginatedRequestType(operation, parameters);

            builder
                .Append($"    [Route(\"{operation.Route}\", \"{operation.Method}\")]\r\n")
                .Append($"    public class {operationName} : {responseDtoType}{PaginatedRequestConstraint(paginatedRequestType)}\r\n")
                .Append($"    {{\r\n")
                .Append(
                    $"        {string.Join("\r\n        ", parameters.Select(CreateRequestDtoProperty))}\r\n")
                .Append($"    }}\r\n");

            return builder.ToString();
        }

        private static string GetResponseDtoType(Operation operation)
        {
            var responseBaseType = GetResponseBaseType(operation);

            if (string.IsNullOrEmpty(responseBaseType))
                return "IReturnVoid";

            return $"IReturn<{responseBaseType}>";
        }

        private static string GetResponseBaseType(Operation operation)
        {
            var response = operation.SuccessResponse();

            if (response?.Schema == null)
                return null;

            var schema = response.Schema;

            return TypeMapper.Map(schema);
        }

        private string GetPaginatedRequestType(Operation operation, List<OperationParameter> parameters)
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

        private string PaginatedRequestConstraint(string paginatedRequestType)
        {
            return string.IsNullOrEmpty(paginatedRequestType)
                ? string.Empty
                : ", IPaginatedRequest";
        }

        private string GetPaginatedResponseType(Definition definition)
        {
            var totalCount = definition.Properties.FirstOrDefault(p => p.Type == Type.Integer && p.Name.Equals("TotalCount", StringComparison.InvariantCultureIgnoreCase));
            var cursor = definition.Properties.FirstOrDefault(p => p.Type == Type.String && p.Name.Equals("Cursor", StringComparison.InvariantCultureIgnoreCase));
            var domainObjects = definition.Properties.FirstOrDefault(p => p.Type == Type.Array && p.Name.Equals("DomainObjects", StringComparison.InvariantCultureIgnoreCase));

            if (totalCount == null || cursor == null || domainObjects == null)
                return null;

            return domainObjects.ArrayTypeName();
        }

        private string PaginatedResponseConstraint(string paginatedResponseType)
        {
            return string.IsNullOrEmpty(paginatedResponseType)
                ? string.Empty
                : $" : IPaginatedResponse<{paginatedResponseType}>";
        }

        private string GetOperationName(Operation operation)
        {
            var fixupKey = $"{operation.Method}:{operation.Route}";

            string fixupName;
            return RequestDtoFixups.TryGetValue(fixupKey, out fixupName)
                ? fixupName
                : operation.OperationId.ToPascalCase();
        }

        private IEnumerable<OperationParameter> GetOperationParameters(Operation operation)
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
                            return new OperationParameter[0];
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

        private static OperationParameter Map(Property property)
        {
            if (property == null)
                return null;

            return new OperationParameter
            {
                Name = property.Name,
                Type = property.Type,
                Format = property.Format,
                SimpleRef = property.SimpleRef,
                Items = Map(property.Items),
                EnumTypeName = property.EnumTypeName,
                Enum = property.Enum,
            };
        }

        private string CreateRequestDtoProperty(OperationParameter parameter)
        {
            var parameterTypeName = ResolveTypeName(parameter);

            if (!parameter.Required)
            {
                var isNullable = false;

                switch (parameter.Type)
                {
                    case Type.Boolean:
                    case Type.Integer:
                    case Type.Number:
                    case Type.Enum:
                        isNullable = true;
                        break;

                    default:
                        if (parameterTypeName == "Instant")
                            isNullable = true;
                        break;
                }

                if (isNullable)
                    parameterTypeName += "?";
            }

            return $"public {parameterTypeName} {ResolveName(parameter)} {{ get; set; }}";
        }
    }
}
