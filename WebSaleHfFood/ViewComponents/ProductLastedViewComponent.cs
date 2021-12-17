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
    public class ProductLastedViewComponent: ViewComponent
    {
        private readonly HfMartContext _context;

        public ProductLastedViewComponent(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _context.ProductVariant.OrderByDescending(x => x.CreatedDate).Select(a => new ProductLastedViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Img = Configuration.GetValue<string>("urladmin") + a.Img,
                CreatedDate = a.CreatedDate,
                Price = a.Price??0
            }).Take(3).ToListAsync();
            return View(result);
        }
    }
}
