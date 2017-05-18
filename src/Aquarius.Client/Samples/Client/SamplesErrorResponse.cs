using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class SamplesErrorResponse
    {
        public ResponseStatus ResponseStatus { get; } = new ResponseStatus();

        public string Message
        {
            get { return ResponseStatus.Message; }
            set { ResponseStatus.Message = value; }
        }

        public string ErrorCode
        {
            get { return ResponseStatus.ErrorCode; }
            set { ResponseStatus.ErrorCode = value; }
        }

        public string StackTrace
        {
            get { return ResponseStatus.StackTrace; }
            set { ResponseStatus.StackTrace = value; }
        }
    }
}
