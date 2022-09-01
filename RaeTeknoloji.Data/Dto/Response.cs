using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReaTeknoloji.Data.Dto
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public bool IsSuccess { get; set; }
    }
}
