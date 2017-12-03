using System.Runtime.Serialization;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Definition : ITypedItem
    {
        public Definition()
        {
            Properties = new Property[0];
        }

        public Type Type { get; set; }
        public string Format { get; set; }
        public string Ref { get; set; }
        public string Name { get; set; }
        public bool Simple { get; set; }

        [IgnoreDataMember]
        public Property[] Properties { get; set; }

        public string[] Enum { get; set; }
        public string EnumTypeName { get; set; }

        public string ArrayTypeName()
        {
            return null;
        }
    }
}
