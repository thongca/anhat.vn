using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class CategoryHighlightViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<ProductHighlightViewModel> Products { get; set; }
    }
    public class ProductHighlightViewModel
    {
        public string Img { get; set; }
        public string Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ")]
        public double Price { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string GroupId { get; set; }
    }
    public class CategoryViewModel
    {
        public string GroupId { get; set; }
        public string Name { get; set; }
    }
}
