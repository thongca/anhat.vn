using Hfmart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class ProductInfoDetailViewModel
    {
        public string Ingredients { get; set; }
        public string MoreInfo { get; set; }
        public string Description { get; set; }
        public ProductCommentViewModel FeaturedReview { get; set; }
        public IEnumerable<NutritionFactViewModel> NutritionFacts { get; set; }
        public IEnumerable<ProductCommentViewModel> ProductComments { get; set; }
    }
    public class ProductCommentViewModel
    {
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public ProductCommentViewModel()
        {

        }
        public ProductCommentViewModel(ProductComment productComment)
        {
            Comment = productComment.Comment;
            CreatedDate = productComment.CreatedDate;
            FullName = productComment.FullName;
            Address = productComment.Address;
            Rating = productComment.Rating;
        }
    }
    public class NutritionFactViewModel
    {
        public string NutritionFactName { get; set; }
        public string NutritionFactValue { get; set; }
        public string ParentId { get; set; }
        public double NutritionFactPercent { get; set; }
        public string ProductId { get; set; }
        public string ProductVariantId { get; set; }
        public NutritionFactViewModel()
        {

        }
        public NutritionFactViewModel(NutritionFact nutritionFact)
        {
            NutritionFactName = nutritionFact.NutritionFactName;
            NutritionFactValue = nutritionFact.NutritionFactValue;
            ParentId = nutritionFact.ParentId;
            NutritionFactPercent = nutritionFact.NutritionFactPercent??0;
            ProductId = nutritionFact.ProductId;
            ProductVariantId = nutritionFact.ProductVariantId;
        }
    }
}
