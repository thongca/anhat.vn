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
    public class NewsViewComponent : ViewComponent
    {
        private readonly HfMartContext _context;

        public NewsViewComponent(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _context.News.OrderByDescending(x => x.CreatedDate)
                .Select(b => new NewsViewModel(b, Configuration.GetValue<string>("urladmin"))).AsNoTracking().Take(3).ToListAsync();
            return View(data);
        }
    }

}
