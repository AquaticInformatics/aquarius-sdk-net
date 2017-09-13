namespace SamplesServiceModelGenerator.Swagger
{
    public interface ITypedItem
    {
        string Name { get; set; }
        Type Type { get; set; }
        string Format { get; set; }
        string SimpleRef { get; set; }
        string[] Enum { get; set; }
        string EnumTypeName { get; set; }
        
        string ArrayTypeName();
    }
}
