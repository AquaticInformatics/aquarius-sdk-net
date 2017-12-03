using System.Runtime.Serialization;

namespace SamplesServiceModelGenerator.Swagger
{
    public class OperationSchema : ITypedItem
    {
        public string Name { get; set; }
        public Type Type { get; set; } = Type.Ref;
        public string Format { get; set; }
        public string Ref { get; set; }
        public string[] Enum { get; set; }
        public string EnumTypeName { get; set; }
        public OperationParameter Items { get; set; }
        public bool Required { get; set; }

        public string ArrayTypeName()
        {
            return TypeMapper.Map(Items);
        }
    }
}
