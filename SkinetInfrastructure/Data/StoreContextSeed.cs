﻿using SkinetCore.Entities;
using System.Text.Json;

namespace SkinetInfrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task Seed(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../SkinetInfrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                await context.ProductBrands.AddRangeAsync(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../SkinetInfrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                await context.ProductTypes.AddRangeAsync(types);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../SkinetInfrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                await context.Products.AddRangeAsync(products);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
