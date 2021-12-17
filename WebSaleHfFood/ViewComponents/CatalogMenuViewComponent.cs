using Hfmart.Domain.ModelEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleHfFood.ViewModels;

namespace WebSaleHfFood.ViewComponents
{
    public class CatalogMenuViewComponent: ViewComponent
    {
        private readonly HfMartContext _context;

        public CatalogMenuViewComponent(HfMartContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.ProductGroup.Where(x => x.Active).OrderBy(x => x.sortBy)
                 .Select(b => new ProductGroupViewModel
                 {
                     Id = b.Id,
                     Name = b.Name
                 }).AsNoTracking().ToListAsync();
            return View(data);
        }
    }
}
