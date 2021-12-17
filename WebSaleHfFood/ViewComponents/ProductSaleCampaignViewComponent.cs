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
    public class ProductSaleCampaignViewComponent : ViewComponent
    {
        private readonly HfMartContext _context;

        public ProductSaleCampaignViewComponent(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<IViewComponentResult> InvokeAsync(string sortBy)
        {
            var data = _context.GetProductPriceProcedure.FromSqlRaw("EXECUTE GetProductCampaigns {0}", Configuration.GetValue<string>("urladmin")).AsEnumerable();
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
            var result = data.Select(a => new ProductSaleViewModel
            {
                Id = a.VariantId,
                
                Name = a.Name,
                Price = a.Price,
                SalePrice = a.Price * (1 - a.Discount / 100) ?? 0,
                Catagory = a.GroupName,
                SizeId = a.SizeId,
                Size = a.Size,
                PercentDiscount = a.Discount??0,
                ImgHome = a.Img,
            });
            return View(result);
        }
    }
}
