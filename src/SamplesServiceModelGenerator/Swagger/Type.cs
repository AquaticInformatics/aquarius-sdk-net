namespace SamplesServiceModelGenerator.Swagger
{
    public enum Type
    {
        Unknown,
        Integer,
        String,
        Boolean,
        Number,
        Byte,
        Object,
        Array,
        Ref,
        File,
        Enum, // A hack, not technically part of the Swagger spec
    }
}
