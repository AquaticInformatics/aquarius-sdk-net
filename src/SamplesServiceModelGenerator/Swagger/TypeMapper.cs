using System;
using System.Collections.Generic;
using ServiceStack;

namespace SamplesServiceModelGenerator.Swagger
{
    public static class TypeMapper
    {
        private static readonly string DefaultFormat = string.Empty;

        public static string Map(ITypedItem item)
        {
            switch (item.Type)
            {
                case Type.Enum:
                    if (string.IsNullOrEmpty(item.EnumTypeName))
                        throw new ArgumentException($"Cannot resolve enumeration typename for {item.ToJson()}");

                    return item.EnumTypeName;
                case Type.Ref:
                    if (string.IsNullOrEmpty(item.SimpleRef))
                        throw new ArgumentException($"Cannot resolve reference for {item.ToJson()}");

                    return item.SimpleRef;
                case Type.Array:
                    var arrayTypeName = item.ArrayTypeName();
                    if (string.IsNullOrEmpty(arrayTypeName))
                        throw new ArgumentException($"Cannot resolve array type for {item.ToJson()}");

                    return $"List<{arrayTypeName}>";
            }

            Dictionary<string, string> formatsForType;
            if (!TypeMaps.TryGetValue(item.Type, out formatsForType))
            {
                return item.Type.ToString();
            }

            string specificFormat;
            if (formatsForType.TryGetValue(item.Format ?? DefaultFormat, out specificFormat))
                return specificFormat;

            return formatsForType[DefaultFormat];
        }

        private static readonly Dictionary<Type, Dictionary<string, string>> TypeMaps =
            new Dictionary<Type, Dictionary<string, string>>
            {
                { Type.Boolean, new Dictionary<string, string> { { DefaultFormat, "bool"} } },
                { Type.Integer, new Dictionary<string, string> { { DefaultFormat, "int"}, {"int64", "long"} } },
                { Type.String, new Dictionary<string, string> { { DefaultFormat, "string"}, { "date-time", "Instant"} } },
                { Type.Number, new Dictionary<string, string> { { DefaultFormat, "double"} } },
                { Type.Byte, new Dictionary<string, string> { { DefaultFormat, "byte[]"} } },
                { Type.Object, new Dictionary<string, string> { { DefaultFormat, "object"} } },
            };
    }
}
