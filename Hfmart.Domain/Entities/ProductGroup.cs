using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class ProductGroup : ModelBase
    {
        public string Name { get; set; }
        public string Img { get; set; }
        public int sortBy { get; set; }
        public bool Active { get; set; } = true;
    }
}
