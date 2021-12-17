using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class Campaign: ModelBase
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CampaignType Type { get; set; }
        public double Discount { get; set; }
        public string Gift { get; set; }
    }
    public enum CampaignType
    {
        Discount = 0,
        Gift =1
    }
}
