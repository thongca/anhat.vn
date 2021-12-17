using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSaleHfFood.ViewModels
{
    public class HomeViewModel
    {
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string GroupId { get; set; }
        public string SortBy { get; set; }
        public string SearchText { get; set; }
        public IEnumerable<HomeCategory> HomeCategories { get; set; }
    }
    public class HomeCategory
    {
        public string GroupId { get; set; }
        public string Name { get; set; }
    }
}
