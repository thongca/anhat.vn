using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hfmart.Domain.Entities;
using Hfmart.Domain.EntitiesProcedures;

namespace Hfmart.Domain.ModelEntity
{
    public class HfMartContext: DbContext
    {
        public HfMartContext(DbContextOptions<HfMartContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ProductComment> ProductComment { get; set; }
        public DbSet<NutritionFact> NutritionFact { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<ProductImg> ProductImg { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }
        public DbSet<ProductVariantPrice> ProductVariantPrice { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Campaign> Campaign { get; set; }


        public DbSet<GetProductPriceProcedure> GetProductPriceProcedure { get; set; }
    }
}
