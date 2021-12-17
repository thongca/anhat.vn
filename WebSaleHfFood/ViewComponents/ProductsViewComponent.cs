using Hfmart.Domain.ModelEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleHfFood.ViewModels;

namespace WebSaleHfFood.ViewComponents
{
    public class ProductsViewComponent: ViewComponent
    {
        private readonly HfMartContext _context;

        public ProductsViewComponent(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<IViewComponentResult> InvokeAsync(string groupId, double? minprice, double? maxprice, string sortBy, string categoryName)
        {
            var data = _context.GetProductPriceProcedure.FromSqlRaw("EXECUTE GetProducts  {0}", Configuration.GetValue<string>("urladmin")).AsEnumerable();
            if (!string.IsNullOrEmpty(groupId))
            {
                data = data.Where(x => x.GroupId == groupId);
            }
            if (minprice.HasValue)
            {
                data = data.Where(x => x.Price >= minprice);
            }
            if (maxprice.HasValue)
            {
                data = data.Where(x => x.Price <= maxprice);
            }
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "pricemintomax":
                        data = data.OrderBy(x => x.Price);
                        break;
                    case "pricemaxtomin":
                        data = data.OrderByDescending(x => x.Price);
                        break;
                    case "productname":
                        data = data.OrderBy(x => x.Name);
                        break;
                    case "gmv":
                        data = data.OrderBy(x => x.Name);
                        break;
                    default:
                        data = data.OrderBy(x => x.Name);
                        break;
                }
            }
            var result = new ProductHomeViewModel
            {
                CountProduct = 2,
                Total = data.Count(),
                GroupId = groupId,
                CategoryName = categoryName,
                Products =  data.Select(a => new ProductViewModel {
                    Id = a.ProductId,
                    Name = a.Name,
                    Img =  a.Img,
                    Price = a.Price,
                    Unit = a.Unit,
                    VariantId = a.VariantId,
                    GroupId = a.GroupId,
                    SizeId = a.SizeId,
                    Size = a.Size
                })
            };
            return View(result);
        }
    }
}
