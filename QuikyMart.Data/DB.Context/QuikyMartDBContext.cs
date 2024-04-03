using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Data.DB.Context
{
    public class QuikyMartDBContext : DbContext  
    {
        public QuikyMartDBContext(DbContextOptions<QuikyMartDBContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
