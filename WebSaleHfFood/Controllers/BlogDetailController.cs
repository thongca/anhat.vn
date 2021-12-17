using Hfmart.Domain.ModelEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSaleHfFood.ViewModels;

namespace WebSaleHfFood.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly HfMartContext _context;

        public BlogDetailController(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<IActionResult> Index(string id)
        {
            var data = await _context.News.Where(x => x.Id == id)
                  .Select(b => new NewsViewModel(b, Configuration.GetValue<string>("urladmin"))).AsNoTracking().FirstOrDefaultAsync();
            return View(data);
        }
    }
}
