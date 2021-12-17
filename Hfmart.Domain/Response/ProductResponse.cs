using Hfmart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Response
{
    public class ProductResponse
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int RatingNumber { get; set; }
        public string Unit { get; set; }
        public int GroupId { get; set; }
        public ProductResponse()
        {

        }
        public ProductResponse(Product product)
        {

        }
    }
}
