using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuikyMart.Data.Entites;
using QuikyMart.Data.Entites.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Data.DB.Context
{
    public class QuikyMartDBContext : DbContext  
    {
        public QuikyMartDBContext(DbContextOptions<QuikyMartDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        //public DbSet<GeCode> GeCode { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethod { get; set; }
        public DbSet<OrderR> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }


    }
}
