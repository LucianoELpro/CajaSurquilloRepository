using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public bool Accomplished { get; set; }
        public T Data { get; set; }

        public Response(T data,string message = null )
        {
            Message = message;
            Data = data;
            Accomplished = true;
        }
        public Response(string message)
        {
            Accomplished=false;
            Message = message;
        }
        public Response()
        {

        }
    }
}
