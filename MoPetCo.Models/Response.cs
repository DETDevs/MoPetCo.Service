using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoPetCo.Models
{
    public class Response<T>
    {
        public T Content { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
