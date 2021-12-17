using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class OrderDetail : ModelBase
    {
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public string VariantUnit { get; set; }
        public int Quantity { get; set; }
        public double PriceSale { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ProductVariantId { get; set; }
        public string SizeId { get; set; }
    }
}
