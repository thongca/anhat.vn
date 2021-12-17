using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfmart.Domain.Request
{
   public class NutritionFactRequest
    {
        public string Id { get; set; }
        public string NutritionFactName { get; set; }
        public string NutritionFactValue { get; set; }
        public string ParentId { get; set; }
        public double NutritionFactPercent { get; set; }
        public string ProductId { get; set; }
        public string ProductVariantId { get; set; }
    }
}
