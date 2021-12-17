using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class ProductSaleViewModel
    {
        public string ProductId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public double? Price { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public double SalePrice { get; set; }
        public string Catagory { get; set; }
        public double PercentDiscount { get; set; }
        public string ImgHome { get; set; }
        public string SizeId { get; set; }
        public string Unit { get; set; }
        public double? Size { get; set; }
    }
}
