using Hfmart.AdminApi.Interfaces;
using Hfmart.Domain;
using Hfmart.Domain.Entities;
using Hfmart.Domain.ModelEntity;
using Hfmart.Domain.Request;
using Hfmart.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hfmart.AdminApi.Services
{
    public class ProductService : IBaseService<ProductRequest, SearchBase, Product, ResponseBase<ProductResponse>, ProductResponse>
    {
        private readonly HfMartContext _context;
        public ProductService(HfMartContext context)
        {
            _context = context;
        }
        public HttpStatusCode CreateItem(ProductRequest request, RequestToken token)
        {
            if (CheckExistCode(request) == true)
            {
                return HttpStatusCode.BadRequest;
            }
            Product obj = new Product(request);
            obj = DataDefault(obj, token);
            _context.Product.Add(obj);
            _context.SaveChanges();
            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeletedItem(string Id, RequestToken token)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return HttpStatusCode.BadRequest;
            }
            var data = _context.Product.Find(Id);
            _context.Product.Remove(data);
            _context.SaveChanges();
            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeletedItems(List<string> Ids, RequestToken token)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode EditItem(ProductRequest request, RequestToken token)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                return HttpStatusCode.BadRequest;
            }
            var data = _context.Product.Find(request.Id);
            data.Name = request.Name;
           
            _context.SaveChanges();
            return HttpStatusCode.OK;
        }

        public ProductResponse GetItem(string Id, RequestToken token)
        {
            var data = _context.Product.Find(Id);
            return new ProductResponse(data);
        }

        public ResponseBase<ProductResponse> GetItems(SearchBase request, RequestToken token)
        {
            var data = from a in _context.ProductVariant
                       join b in _context.Product on a.ProductId equals b.Id
                       select new ProductResponse(b);
            var result = PageHelper.GetPage(data, request);
            return result;
        }
        public Product DataDefault(Product data, RequestToken token)
        {
            return data;
        }
        /// <summary>
        /// Kiểm tra tồn tại của mã
        /// </summary>
        /// <param name="request"></param>
        /// <returns>true = đã tồn tại, false = chưa tồn tại</returns>
        public bool CheckExistCode(ProductRequest request)
        {
            var code_exist = _context.Product.Count(x => x.Id == request.Id);
            if (code_exist > 0)
            {
                return true;
            }
            return false;
        }
    }
}
