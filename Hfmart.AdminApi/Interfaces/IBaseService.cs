using Hfmart.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hfmart.AdminApi.Interfaces
{
   public interface IBaseService<in T, in T2, T3, out TResult, out TResult1>
    {
        public HttpStatusCode CreateItem(T request, RequestToken token);
        public HttpStatusCode EditItem(T request, RequestToken token);
        public HttpStatusCode DeletedItem(string Id, RequestToken token);
        public HttpStatusCode DeletedItems(List<string> Ids, RequestToken token);
        public TResult1 GetItem(string Id, RequestToken token);
        public TResult GetItems(T2 request, RequestToken token);
        public T3 DataDefault(T3 data, RequestToken token);
        /// <summary>
        /// Kiểm tra tồn tại của mã
        /// </summary>
        /// <param name="request"></param>
        /// <returns>true = đã tồn tại, false = chưa tồn tại</returns>
        public bool CheckExistCode(T request);
    }
}
