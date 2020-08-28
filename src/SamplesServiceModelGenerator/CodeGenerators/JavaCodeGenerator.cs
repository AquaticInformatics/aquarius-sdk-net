using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SamplesServiceModelGenerator.Swagger;
using ServiceStack;
using Enum = SamplesServiceModelGenerator.Swagger.Enum;

namespace SamplesServiceModelGenerator.CodeGenerators
{
    public class JavaCodeGenerator : CodeGeneratorBase
    {
        protected override string BeginFile()
        {
            return $"// Date: {GenerationTime:O}\r\n"
                   + $"// Base URL: {Api.BaseUrl}\r\n"
                   + $"// Source: {Api.Title} ({Api.Version})\r\n"
                   + "\r\n"
                   + $"package {Namespace};\r\n"
                   + "\r\n"
                   + string.Join("", UsingDirectives.Select(name => $"import {name};\r\n"))
                   + "\r\n";
        }

        protected override string EndFile()
        {
            return string.Empty;
        }

        protected override string BeginNamespace()
        {
            return $"public class {System.IO.Path.GetFileNameWithoutExtension(Filename)}\r\n"
                   + "{\r\n"
                   + $"    public static class Current\r\n"
                   + $"    {{\r\n"
                   + $"        public static final AquariusServerVersion Version = AquariusServerVersion.Create(\"{Api.Version}\");\r\n"
                   + $"    }}\r\n";
        }

        protected override string EndNamespace()
        {
            return "}\r\n";
        }

        protected override string AllRequestDtos()
        {
            var code = string.Join("\r\n", Api.Paths.Select(CreateRequestDtos));

            if (ObsoleteDtos.Any())
            {
                code += "\r\n" + string.Join("\r\n", ObsoleteDtos.Select(p => $"    @Deprecated public class {p.Key} extends {p.Value} {{}}"));
            }

            return code;
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
            ThrowIfInvalidPoco(definition);

            var builder = new StringBuilder();

            if (Aliases.ContainsKey(definition.Name))
                return string.Empty;

            var className = definition.Name;

            builder.Append($"    public static class {className}");

            if (definition.Simple)
            {
                builder.Append($" : {TypeMapper.Map(definition)}"); // TODO: Figure this out
            }
            else
            {
                builder.Append(PaginatedResponseConstraint(GetPaginatedResponseType(definition)));
            }

            var properties = definition.Properties
                .Select(p => new Tuple<string, string>(ResolveName(p), ResolveTypeName(p)))
                .ToList();

            builder
                .Append("\r\n    {\r\n")
                .Append(CreateDtoProperties(className, properties))
                .Append("    }\r\n");

            return builder.ToString();
        }

        private string CreateEnum(Enum enumType)
        {
            var builder = new StringBuilder();

            builder
                .Append($"    public static enum {enumType.EnumTypeName}\r\n")
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

            var properties = parameters
                .Select(p => new Tuple<string,string>(ResolveName(p), ResolveTypeName(p)))
                .ToList();

            builder
                .Append($"    @Route(Path=\"{operation.Route}\", Verbs=\"{operation.Method}\")\r\n")
                .Append($"    public static class {operationName} implements {responseDtoType}{PaginatedRequestConstraint(paginatedRequestType)}\r\n")
                .Append($"    {{\r\n")
                .Append(CreateDtoProperties(operationName, properties))
                .Append(CreateSingletonResponseType(operation))
                .Append($"    }}\r\n");

            return builder.ToString();
        }

        private string CreateDtoProperties(string className, List<Tuple<string, string>> properties)
        {
            if (!properties.Any())
                return string.Empty;

            return $"        {string.Join("\r\n        ", properties.Select(p => CreateDtoProperty(p.Item1, p.Item2)))}\r\n"
                    + $"\r\n"
                    + $"        {string.Join("\r\n        ", properties.Select(p => CreateDtoPropertyAccessors(className, p.Item1, p.Item2)))}\r\n";
        }

        private string CreateDtoProperty(string propertyName, string propertyTypeName)
        {
            // TODO: Add @ApiMember annotations to show parameter.Description if not empty
            return $"public {propertyTypeName} {propertyName} = null;";
        }

        private string CreateDtoPropertyAccessors(string className, string propertyName, string propertyTypeName)
        {
            return $"public {propertyTypeName} get{propertyName}() {{ return {propertyName}; }}\r\n"
                + $"        public {className} set{propertyName}({propertyTypeName} value) {{ this.{propertyName} = value; return this; }}";
        }

        private string CreateSingletonResponseType(Operation operation)
        {
            var responseBaseType = GetResponseBaseType(operation);

            if (string.IsNullOrEmpty(responseBaseType))
                return string.Empty;

            return $"        private static Object responseType = {GetResponseTypeExpression(responseBaseType)};\r\n"
                   + "        public Object getResponseType() {{ return responseType; }}\r\n";
        }

        private static string GetResponseTypeExpression(string responseBaseType)
        {
            return GenericRegex.IsMatch(responseBaseType)
                ? $"new TypeToken<{responseBaseType}>(){{}}" // Thanks Java type-erasure!
                : $"{responseBaseType}.class";
        }

        private static readonly Regex GenericRegex = new Regex(@"^\w+<\w+>$");

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
                : $" implements IPaginatedResponse<{paginatedResponseType}>";
        }

        private string PaginatedRequestConstraint(string paginatedRequestType)
        {
            return string.IsNullOrEmpty(paginatedRequestType)
                ? string.Empty
                : ", IPaginatedRequest";
        }
    }
}
