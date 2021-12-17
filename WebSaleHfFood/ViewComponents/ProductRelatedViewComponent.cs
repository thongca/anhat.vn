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
    public class ProductRelatedViewComponent: ViewComponent
    {
        private readonly HfMartContext _context;

        public ProductRelatedViewComponent(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public async Task<IViewComponentResult> InvokeAsync(string groupId)
        {
            var data = _context.GetProductPriceProcedure.FromSqlRaw("EXECUTE GetRelateProducts {0}, {1}", Configuration.GetValue<string>("urladmin"), groupId).AsEnumerable();
            var result = data.Select(a => new RelatedProductViewModel
            {
                Id = a.ProductId,
                CampaignId = a.CampaignId,
                Name = a.Name,
                Img = a.Img,
                Price = a.Price,
                Unit = a.Unit,
                VariantId = a.VariantId,
                GroupId = a.GroupId,
                SalePrice = a.Price * (1 - a.Discount / 100) ?? 0,
                PercentDiscount = a.Discount??0
            });
            return View(result);
        }
    }
}
