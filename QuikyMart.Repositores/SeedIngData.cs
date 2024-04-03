using Microsoft.Extensions.Logging;
using QuikyMart.Data.DB.Context;
using QuikyMart.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuikyMart.Repositories
{
    public class SeedIngData
    {

        public static async Task SeedingData(QuikyMartDBContext context , ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var types = File.ReadAllText("../QuikyMart.Repositores/SeedData/types.json");

                    var typesSirlized = JsonSerializer.Deserialize<List<ProductType>>(types);

                    await context.AddRangeAsync(typesSirlized);
                }
                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var Brands = File.ReadAllText("../QuikyMart.Repositores/SeedData/brands.json");

                    var BrandsSirlized = JsonSerializer.Deserialize<List<ProductBrand>>(Brands);

                    await context.AddRangeAsync(BrandsSirlized);
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var Products = File.ReadAllText("../QuikyMart.Repositores/SeedData/products.json");

                    var ProductsSirlized = JsonSerializer.Deserialize<List<Product>>(Products);

                    await context.AddRangeAsync(ProductsSirlized);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedIngData>();
                logger.LogError(ex.Message);
            }
        }

    }
}
