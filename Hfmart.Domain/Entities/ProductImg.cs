using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class ProductImg : ModelBase
    {
        public string ImgHome { get; set; }
        public string ProductId { get; set; }
        public string ProductVariantId { get; set; }
        public int SortBy { get; set; }
        public string ImgSeo { get; set; }
        public string ImgZoom { get; set; }
    }
}
