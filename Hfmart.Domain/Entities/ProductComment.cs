using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class ProductComment : ModelBase
    {
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
        public string ProductId { get; set; }
        public string ProductVariantId { get; set; }
    }
}
