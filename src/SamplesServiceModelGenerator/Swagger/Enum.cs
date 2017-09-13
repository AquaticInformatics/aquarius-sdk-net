using ServiceStack;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Enum
    {
        public Enum(ITypedItem owner, ITypedItem source, string[] values)
        {
            Owner = owner;
            Source = source;
            Values = values;
            Source.Type = Type.Enum;

            MakeEnumTypeName(source.Name.ToPascalCase());
        }

        public ITypedItem Source { get; }
        public ITypedItem Owner { get; }
        public string EnumTypeName { get; private set; }
        public string[] Values { get; }

        public void MakeEnumTypeName(string name)
        {
            const string enumSuffix = "Type";

            if (!name.EndsWith(enumSuffix))
                name += enumSuffix;

            EnumTypeName = name;
            Source.EnumTypeName = name;
        }

        public void MakeDistinctEnumTypeName()
        {
            var name = Owner.Name.ToPascalCase() + Source.Name.ToPascalCase();

            MakeEnumTypeName(name);
        }
    }
}
