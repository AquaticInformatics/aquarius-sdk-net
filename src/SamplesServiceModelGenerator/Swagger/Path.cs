using System.Collections.Generic;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Path
    {
        public string Route { get; set; }
        public Dictionary<string,Operation> Operations { get; set; }
    }
}
