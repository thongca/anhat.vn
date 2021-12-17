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
    public class ProductInfoDetailViewComponent: ViewComponent
    {
        private readonly HfMartContext _context;

        public ProductInfoDetailViewComponent(HfMartContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string variantId)
        {
            var data = await _context.ProductVariant.Where(x => x.Id == variantId)
                 .Select(b => new ProductInfoDetailViewModel
                 {
                     Ingredients = b.Ingredients,
                     MoreInfo = b.MoreInfo,
                     Description = b.Description
                 }).AsNoTracking().FirstOrDefaultAsync();
            var comments = await _context.ProductComment.Where(x => x.ProductVariantId == variantId)
                .Select(a => new ProductCommentViewModel(a)).ToListAsync();
            var nutritions = await _context.NutritionFact.Where(x => x.ProductVariantId == variantId)
                .Select(a => new NutritionFactViewModel(a)).ToListAsync();
            var featuredReview = comments.OrderBy(x => x.Rating).FirstOrDefault();
            if (data != null)
            {
                data.NutritionFacts = nutritions;
                data.ProductComments = comments;
                data.FeaturedReview = featuredReview;
            }
            return View(data);
        }
    }
}
