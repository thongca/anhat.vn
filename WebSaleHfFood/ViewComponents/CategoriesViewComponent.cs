using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hfmart.Domain.ModelEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSaleHfFood.ViewModels;

namespace WebSaleHfFood.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly HfMartContext _context;

        public CategoriesViewComponent(HfMartContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.ProductGroup.Where(x => x.Active && x.Id != "a1").OrderBy(x => x.sortBy)
                 .Select(b => new ProductGroupViewModel
                 {
                     Id = b.Id,
                     Name = b.Name,
                     Img = b.Img
                 }).AsNoTracking().ToListAsync();
            return View(data);
        }
    }
}
