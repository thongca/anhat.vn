using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class RelatedProductViewModel
    {
        public string Id { get; set; }
        public string VariantId { get; set; }
        public string CampaignId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public double Price { get; set; }
        public string Unit { get; set; }
        public string Img { get; set; }
        public string GroupId { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public double SalePrice { get; set; }
        public double PercentDiscount { get; set; }
        public double? Size{ get; set; }

    }
}
