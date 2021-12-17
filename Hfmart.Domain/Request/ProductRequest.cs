using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Request
{
    public class ProductRequest
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SeoContend { get; set; }
        public string Unit { get; set; }
        public string GroupId { get; set; }
        public string Img { get; set; }
        public string ImgSeo { get; set; }
        public double? Price { get; set; }
        public string Ingredients { get; set; }
        public string MoreInfo { get; set; }
        public string CampaignId { get; set; }
        
        public IEnumerable<ProductImgRequest> ProductImgs { get; set; }
        public IEnumerable<ProductSizeRequest> ProductSizes { get; set; }
        public IEnumerable<NutritionFactRequest> NutritionFacts { get; set; }
    }
    public class ProductImgRequest
    {
        public string Id { get; set; }
        public string ImgZoom { get; set; }
    }
    public class ProductSizeRequest
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public int Size { get; set; }
    }
}
