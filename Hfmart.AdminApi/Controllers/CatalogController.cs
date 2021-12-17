using Hfmart.Domain.Entities;
using Hfmart.Domain.ModelEntity;
using Hfmart.Domain.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly HfMartContext _context;
        public CatalogController(HfMartContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetCampaigns")]
        public async Task<IActionResult> GetCampaigns()
        {
            var result = await _context.Campaign.Select(a => new
            {
                a.Name,
                a.Id
            }).ToListAsync();
            return new ObjectResult(new { data = result, error = 0 });
        }
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _context.Product.Select(a => new
            {
                a.Name,
                a.Id
            }).ToListAsync();
            return new ObjectResult(new { data = result, error = 0 });
        }
        [HttpGet]
        [Route("GetGroups")]
        public async Task<IActionResult> GetGroups()
        {
            var result = await _context.ProductGroup.Select(a => new
            {
                a.Name,
                a.Id
            }).ToListAsync();
            return new ObjectResult(new { data = result, error = 0 });
        }
        [HttpGet]
        [Route("Getnutrition/{varientId}")]
        public async Task<IActionResult> Getnutrition(string varientId)
        {
            var result = await _context.NutritionFact.Where(x => x.ProductVariantId == varientId).Select(a => new
            {
                a.NutritionFactName,
                a.NutritionFactValue,
                a.ParentId,
                a.NutritionFactPercent,
                a.Id
            }).ToListAsync();
            return new ObjectResult(new { data = result, error = 0 });
        }
        //Post: api/MyWorkFlow/r2AssignWork
        [HttpPost]
        [Route("CreatedNutritionFact")]
        public async Task<IActionResult> CreatedNutritionFact(ProductRequest request)
        {
            try
            {
                foreach (var item in request.NutritionFacts)
                {
                    if (string.IsNullOrEmpty(item.Id))
                    {
                        NutritionFact obj = new NutritionFact
                        {
                            Id = Guid.NewGuid().ToString(),
                            NutritionFactName = item.NutritionFactName,
                            NutritionFactPercent = item.NutritionFactPercent,
                            NutritionFactValue = item.NutritionFactValue,
                            ParentId = item.ParentId,
                            ProductId = item.ProductId,
                            ProductVariantId = request.Id,
                        };
                        _context.NutritionFact.Add(obj);
                    }
                    else
                    {
                        var nutrition = _context.NutritionFact.Find(item.Id);
                        nutrition.NutritionFactName = item.NutritionFactName;
                        nutrition.NutritionFactPercent = item.NutritionFactPercent;
                        nutrition.NutritionFactValue = item.NutritionFactValue;
                        nutrition.ParentId = item.ParentId;
                    }

                }
                await _context.SaveChangesAsync();

                return new ObjectResult(new { error = 0, ms = "Thêm mới thành công!" });
            }
            catch (Exception)
            {
                return new ObjectResult(new { error = 1, ms = "Thêm mới lỗi!" });
            }
        }
    }
}
