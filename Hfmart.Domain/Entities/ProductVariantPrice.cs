using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class ProductVariantPrice : ModelBase
    {
        public string VariantId { get; set; }
        public string ProductId { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public double Size { get; set; }
    }
}
