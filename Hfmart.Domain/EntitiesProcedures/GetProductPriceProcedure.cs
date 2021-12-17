using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfmart.Domain.EntitiesProcedures
{
   public class GetProductPriceProcedure
    {
        public string ProductId { get; set; }
        [Key]
        public string VariantId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public string Img { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public double? Discount { get; set; }
        public string CampaignId { get; set; }
        public string SizeId { get; set; }
        public double? Size { get; set; }
    }
}
