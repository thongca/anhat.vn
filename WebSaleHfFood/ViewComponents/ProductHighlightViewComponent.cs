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
    public class ProductHighlightViewComponent : ViewComponent
    {
        private readonly HfMartContext _context;

        public ProductHighlightViewComponent(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<IViewComponentResult> InvokeAsync(string sortBy)
        {
            var data = (from b in _context.ProductVariant
                              join a in _context.Product on b.ProductId equals a.Id
                              select new ProductHighlightViewModel
                              {
                                  Id = b.Id,
                                  Img = Configuration.GetValue<string>("urladmin") + b.Img,
                                  Name = b.Name,
                                  Price = b.Price ?? 0,
                                  CreatedDate = b.CreatedDate,
                                  GroupId = a.GroupId
                              });
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
            var prods = await data.Take(8).ToListAsync();
            var categories = await _context.ProductGroup.Where(x => x.Active == true && x.Id != "a1").Select(a => new CategoryViewModel
            {
                GroupId = a.Id,
                Name = a.Name
            }).ToListAsync();
            var result = new CategoryHighlightViewModel
            {
                Categories = categories,
                Products = prods
            };
            return View(result);
        }
    }
}
