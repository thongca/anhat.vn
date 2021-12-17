using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class Order : ModelBase
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMobile { get; set; }
        public string OrderDelivery { get; set; }
        public DateTime OrderDeliveryTime { get; set; }
        public string Note { get; set; }
        public string FeedBack { get; set; }
        public double TotalPayment { get; set; }
    }
}
