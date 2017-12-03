using System.Linq;
using System.Text;
using SamplesServiceModelGenerator.Swagger;

namespace SamplesServiceModelGenerator.CodeGenerators
{
    public class CSharpCodeGenerator : CodeGeneratorBase
    {
        protected override string BeginFile()
        {
            return $"// Date: {GenerationTime:O}\r\n"
                   + $"// Base URL: {Api.BaseUrl}\r\n"
                   + $"// Source: {Api.Title} ({Api.Version})\r\n"
                   + "\r\n"
                   + string.Join("", UsingDirectives.Select(name => $"using {name};\r\n"))
                   + "// ReSharper disable InconsistentNaming\r\n"
                   + "\r\n";
        }

        protected override string EndFile()
        {
            return string.Empty;
        }

        protected override string BeginNamespace()
        {
            return "// ReSharper disable once CheckNamespace\r\n"
                   + $"namespace {Namespace}\r\n"
                   + "{\r\n"
                   + $"    public static class Current\r\n"
                   + $"    {{\r\n"
                   + $"        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create(\"{Api.Version}\");\r\n"
                   + $"    }}\r\n";
        }

        protected override string EndNamespace()
        {
            return "}\r\n";
        }

        protected override string AllRequestDtos()
        {
            return string.Join("\r\n", Api.Paths.Select(CreateRequestDtos));
        }

        protected override string AllPocos()
        {
            return string.Join("\r\n", Api.Definitions.Select(CreatePoco));
        }

        protected override string AllEnums()
        {
            return string.Join("\r\n", Api.Enums.Select(CreateEnum));
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
                builder.Append($"        public {ResolveTypeName(property)} {ResolveName(property)} {{ get; set; }}\r\n");
            }

            builder.Append("    }\r\n");

            return builder.ToString();
        }

        private string CreateEnum(Enum enumType)
        {
            var builder = new StringBuilder();

            builder
                .Append($"    public enum {enumType.EnumTypeName}\r\n")
                .Append("    {\r\n")
                .Append($"        {string.Join(",\r\n        ", enumType.Values)}\r\n")
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
                .Append($"        {string.Join("\r\n        ", parameters.Select(CreateRequestDtoProperty))}\r\n")
                .Append($"    }}\r\n");

            return builder.ToString();
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

        private static string GetResponseDtoType(Operation operation)
        {
            var responseBaseType = GetResponseBaseType(operation);

            if (string.IsNullOrEmpty(responseBaseType))
                return "IReturnVoid";

            return $"IReturn<{responseBaseType}>";
        }

        private string PaginatedResponseConstraint(string paginatedResponseType)
        {
            return string.IsNullOrEmpty(paginatedResponseType)
                ? string.Empty
                : $" : IPaginatedResponse<{paginatedResponseType}>";
        }

        private string PaginatedRequestConstraint(string paginatedRequestType)
        {
            return string.IsNullOrEmpty(paginatedRequestType)
                ? string.Empty
                : ", IPaginatedRequest";
        }
    }
}
