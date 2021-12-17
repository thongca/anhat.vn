using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hfmart.Domain.Request
{
   public class OrderRequest
    {
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public double TotalPayment { get; set; }
        public string AddressDelivery { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public List<OrderDetailRequest> OrderDetails { get; set; }
    }
    public class OrderDetailRequest
    {
        public string id { get; set; }
        public string unit { get; set; }
        public string name { get; set; }
        public double salePrice { get; set; }
        public int quantity { get; set; }
        public string variantSizeId { get; set; }
    }
}
