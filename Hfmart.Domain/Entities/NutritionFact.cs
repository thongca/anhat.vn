using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class NutritionFact: ModelBase
    {
        public string NutritionFactName { get; set; }
        public string NutritionFactValue { get; set; }
        public string ParentId { get; set; }
        public double? NutritionFactPercent { get; set; }
        public string ProductId { get; set; }
        public string ProductVariantId { get; set; }
    }
}
