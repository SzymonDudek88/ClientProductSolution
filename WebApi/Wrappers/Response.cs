namespace WebApi.Wrappers
{
    public class Response <T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }

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
