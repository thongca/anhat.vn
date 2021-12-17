using Hfmart.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class ProductVariant : ModelBase
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        public string Img { get; set; }
        public string ImgSeo { get; set; }
        public string Ingredients { get; set; }
        public string NutritionFactId { get; set; }
        public string MoreInfo { get; set; }
        public string CampaignId { get; set; }
        public string DescriptionSeo { get; set; }
        public double? Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductVariant()
        {

        }
        public ProductVariant(ProductRequest request)
        {
            Name = request.Name;
            Description = request.Description;
            Unit = request.Unit;
            Price = request.Price;
            Img = request.Img;
            ImgSeo = request.ImgSeo;
            MoreInfo = request.MoreInfo;
            CampaignId = request.CampaignId;
            DescriptionSeo = request.SeoContend;
            CreatedDate = DateTime.Now;
        }
    }
}
