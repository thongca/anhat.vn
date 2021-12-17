using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hfmart.Domain.Response
{
    public class ResponseBase<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
