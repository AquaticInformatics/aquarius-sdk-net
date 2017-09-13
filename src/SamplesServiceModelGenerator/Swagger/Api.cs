using System.Collections.Generic;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Api
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string BaseUrl { get; set; }
        public List<Definition> Definitions { get; set; }
        public List<Enum> Enums { get; set; }
        public List<Path> Paths { get; set; }
    }
}
