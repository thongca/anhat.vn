using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class ProductHomeViewModel
    {
        public int CountProduct { get; set; }
        public int Total { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
        public string CategoryName { get; set; }
        public string GroupId { get; internal set; }
    }
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string VariantId { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public double Price { get; set; }
        public string Unit { get; set; }
        public string Img { get; set; }
        public string GroupId { get; set; }
        public string SizeId { get; set; }
        public double? Size { get; set; }
    }
}
