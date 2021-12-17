using Hfmart.Domain.ModelEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebSaleHfFood.Models;
using WebSaleHfFood.ViewModels;

namespace WebSaleHfFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HfMartContext _context;

        public IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, HfMartContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            Configuration = configuration;
        }

        public async Task<IActionResult> Index(string groupId, double? minprice, double? maxprice, string sortBy, string searchText)
        {
           
            var para = new HomeViewModel
            {
                GroupId = groupId,
                MinPrice = minprice ?? 0,
                MaxPrice = maxprice ?? 0,
                SearchText = searchText,
                SortBy = string.IsNullOrEmpty(sortBy) ? "pricemintomax" : sortBy
            };
            var categories = _context.ProductGroup.Select(a => new HomeCategory
            {
                GroupId = a.Id,
                Name = a.Name
            });
            if (!string.IsNullOrEmpty(groupId) && groupId != "a1")
            {
                
                categories = categories.Where(x => x.GroupId == groupId);
            }
            para.HomeCategories =await categories.Where(x => x.GroupId != "a1").ToListAsync();
            return View(para);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
