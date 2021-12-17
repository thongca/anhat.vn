using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class ProductDetailViewModel
    {
        public string VariantId { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public string DescriptionSeo { get; set; }
        public string ImgSeo { get; set; }
        public string GroupId { get; set; }
        public IEnumerable<string> Imgs { get; set; }
        public int RatingNumber { get; set; }
        public IEnumerable<ProductVariantSizeViewModel> VariantSizes { get; set; }
    }
    public class ProductVariantSizeViewModel
    {
        public string Id { get; set; }
        public double Size { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public double Price { get; set; }
        public string Unit { get; set; }
        public double Discount { get; set; }
    }
}
