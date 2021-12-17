using Hfmart.Domain.ModelEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSaleHfFood.ViewModels;

namespace WebSaleHfFood.Controllers
{
    public class ShopDetailController : Controller
    {
        private readonly HfMartContext _context;

        public IConfiguration Configuration { get; }

        public ShopDetailController(HfMartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public async Task<IActionResult> Index(string variantId)
        {
            var variantSizes = await (from a in _context.ProductVariantPrice
                                      join b in _context.ProductVariant on a.VariantId equals b.Id
                                      join c in _context.Campaign on b.CampaignId equals c.Id into camp
                                      from pl in camp.DefaultIfEmpty()
                                      where a.VariantId == variantId
                                      select new ProductVariantSizeViewModel
                                      {
                                          Id = a.Id,
                                          Price = a.Price,
                                          Size = a.Size,
                                          Unit = a.Unit,
                                          Discount = CalPriceSale(a.Price, pl.Discount)
                                      }).ToListAsync();
            var productImgs = await _context.ProductImg
                            .Where(x => x.ProductVariantId == variantId)
                            .Select(a => Configuration.GetValue<string>("urladmin") + a.ImgZoom)
                            .ToListAsync();

            var listProd = await (from a in _context.ProductVariant
                                  join b in _context.Product on a.ProductId equals b.Id
                                  where a.Id == variantId
                                  select new ProductDetailViewModel
                                  {
                                      VariantId = a.Id,
                                      GroupId = b.GroupId,
                                      Name = a.Name,
                                      Rating = b.Rating,
                                      RatingNumber = b.RatingNumber,
                                      Description = a.Description,
                                      VariantSizes = variantSizes,
                                      Imgs = productImgs
                                  }).FirstOrDefaultAsync();

            return View(listProd);
        }
        private static double CalPriceSale(double price, double? discount)
        {
            if (discount == null)
            {
                discount = 0;
            }
            var saleprice = price - price * (discount / 100);
            return saleprice??0;
        }
        public IActionResult setActiveSize(string id)
        {
            TempData["size-variant"] = id;
            return RedirectToAction("Index");
        }
    }
}
