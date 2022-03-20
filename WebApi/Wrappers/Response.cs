using System.Collections.Generic;

namespace WebApi.Wrappers
{
    public class Response <T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }

        public string Message  { get; set; }  // got problems here missing property

        public IEnumerable<string> Errors { get; set; }
        public Response()
        {


        }

        public Response(T data)
        {
            Data = data;
            Success = true;
        }
    }

}
