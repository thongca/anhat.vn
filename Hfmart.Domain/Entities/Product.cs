using Hfmart.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int RatingNumber { get; set; }
        public string Unit { get; set; }
        public string GroupId { get; set; }
        public Product()
        {

        }
        public Product(ProductRequest request)
        {
            Name = request.Name;
            Description = request.Description;
            Rating = 0;
            RatingNumber = 0;
            Unit = request.Unit;
            GroupId = request.GroupId;
        }
    }
}
