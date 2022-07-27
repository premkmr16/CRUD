namespace Utilities.Response
{
    public class ResponseMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponseMessage(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public ResponseMessage(string code, string message, object data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }
}