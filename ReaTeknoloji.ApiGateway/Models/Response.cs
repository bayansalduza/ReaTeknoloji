using System.Net;

namespace ReaTeknoloji.ApiGateway.Models
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
