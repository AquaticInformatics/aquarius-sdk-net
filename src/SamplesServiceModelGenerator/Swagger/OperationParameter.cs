namespace SamplesServiceModelGenerator.Swagger
{
    public class OperationParameter : ITypedItem
    {
        public ParameterType In { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public string Format { get; set; }
        public string SimpleRef { get; set; }
        public string[] Enum { get; set; }
        public string EnumTypeName { get; set; }
        public bool Required { get; set; }
        public OperationSchema Schema { get; set; }
        public OperationParameter Items { get; set; }

        public string ArrayTypeName()
        {
            return TypeMapper.Map(Items);
        }
    }
}
