using System.Runtime.Serialization;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Property : ITypedItem
    {
        public Property()
        {
            Enum = new string[0];
        }

        public string Name { get; set; }
        public Type Type { get; set; }
        public string Format { get; set; }
        public bool Required { get; set; }
        public string SimpleRef { get; set; }
        public Property Items { get; set; }

        public string ArrayTypeName()
        {
            return TypeMapper.Map(Items);
        }

        public string[] Enum { get; set; }

        [IgnoreDataMember]
        public Definition Owner { get; set; }
        [IgnoreDataMember]
        public string EnumTypeName { get; set; }
    }
}
