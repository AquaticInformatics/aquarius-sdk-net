using System;
using System.Collections.Generic;
using ServiceStack;

namespace SamplesServiceModelGenerator.Swagger
{
    public static class TypeMapper
    {
        private static readonly string DefaultFormat = string.Empty;

        public static TargetLanguage Language { get; set; } = TargetLanguage.CSharp;

        public static string Map(ITypedItem item)
        {
            switch (item.Type)
            {
                case Type.Enum:
                    if (string.IsNullOrEmpty(item.EnumTypeName))
                        throw new ArgumentException($"Cannot resolve enumeration typename for {item.ToJson()}");

                    if (item.EnumTypeName == "Unknown")
                        throw new ArgumentException($"Unknown enum type for {item.ToJson()}");

                    return item.EnumTypeName;

                case Type.Ref:
                    if (string.IsNullOrEmpty(item.Ref))
                        throw new ArgumentException($"Cannot resolve reference for {item.ToJson()}");

                    if (item.Ref == "Unknown")
                        throw new ArgumentException($"Unknown refernce type for {item.ToJson()}");

                    return item.Ref;

                case Type.Array:
                    var arrayTypeName = item.ArrayTypeName();
                    if (string.IsNullOrEmpty(arrayTypeName))
                        throw new ArgumentException($"Cannot resolve array type for {item.ToJson()}");

                    if (arrayTypeName == "Unknown")
                        throw new ArgumentException($"Unknown array type for {item.ToJson()}");

                    return $"List<{arrayTypeName}>";
            }

            Dictionary<string, string> formatsForType;
            if (!TypeMaps[Language].TryGetValue(item.Type, out formatsForType))
            {
                var typeName = item.Type.ToString();

                if (typeName == "Unknown")
                    throw new ArgumentException($"Unknown type for {item.ToJson()}");

                return typeName;
            }

            string specificFormat;
            if (formatsForType.TryGetValue(item.Format ?? DefaultFormat, out specificFormat))
                return specificFormat;

            return formatsForType[DefaultFormat];
        }

        private static readonly Dictionary<TargetLanguage, Dictionary<Type, Dictionary<string, string>>> TypeMaps =
            new Dictionary<TargetLanguage, Dictionary<Type, Dictionary<string, string>>>
            {
                {
                    TargetLanguage.CSharp, new Dictionary<Type, Dictionary<string, string>>
                    {
                        {Type.Boolean, new Dictionary<string, string> {{DefaultFormat, "bool"}}},
                        {Type.Integer, new Dictionary<string, string> {{DefaultFormat, "int"}, {"int64", "long"}}},
                        {Type.String, new Dictionary<string, string> {{DefaultFormat, "string"}, {"date-time", "Instant"}}},
                        {Type.Number, new Dictionary<string, string> {{DefaultFormat, "double"}}},
                        {Type.Byte, new Dictionary<string, string> {{DefaultFormat, "byte[]"}}},
                        {Type.Object, new Dictionary<string, string> {{DefaultFormat, "object"}}},
                    }
                },
                {
                    TargetLanguage.Java, new Dictionary<Type, Dictionary<string, string>>
                    {
                        {Type.Integer, new Dictionary<string, string> {{DefaultFormat, "Integer"}}},
                        {Type.String, new Dictionary<string, string> {{DefaultFormat, "String"}, {"date-time", "Instant"}}},
                        {Type.Number, new Dictionary<string, string> {{DefaultFormat, "Double"}}},
                        {Type.Byte, new Dictionary<string, string> {{DefaultFormat, "byte[]"}}},
                    }
                },
            };
    }
}
