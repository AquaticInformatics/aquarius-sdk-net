using System.Collections.Generic;
using System.Linq;

namespace SamplesServiceModelGenerator.Swagger
{
    public class Operation
    {
        public Operation()
        {
            Parameters = new OperationParameter[0];
        }

        public string Route { get; set; }
        public string Method { get; set; }
        public string[] Tags { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string OperationId { get; set; }
        public string[] Consumes { get; set; }
        public string[] Produces { get; set; }
        public OperationParameter[] Parameters { get; set; }
        public Dictionary<string,OperationResponse> Responses { get; set; }

        public OperationResponse SuccessResponse()
        {
            return (from httpStatus in SuccessHttpStatus where Responses.ContainsKey(httpStatus) select Responses[httpStatus])
                .FirstOrDefault();
        }

        private static readonly string[] SuccessHttpStatus = { "200", "204", "default" };
    }
}
