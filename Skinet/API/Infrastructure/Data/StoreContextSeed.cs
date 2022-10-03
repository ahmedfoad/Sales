using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entity;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!storeContext.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var productBrand in productBrands)
                    {
                        storeContext.ProductBrands.Add(productBrand);
                    }
                    await storeContext.SaveChangesAsync();
                }

                if (!storeContext.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if (productTypes != null)
                    {
                        foreach (var productType in productTypes)
                        {
                            storeContext.ProductTypes.Add(productType);
                        }

                        await storeContext.SaveChangesAsync();
                    }
                }

                if (!storeContext.DeliveryTypes.Any())
                {
                    var deliveryData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var deliveries = JsonSerializer.Deserialize<List<Delivery>>(deliveryData);
                    if (deliveries != null)
                    {
                        foreach (var delivery in deliveries)
                        {
                            storeContext.DeliveryTypes.Add(delivery);
                        }

                        await storeContext.SaveChangesAsync();
                    }
                }

                if (!storeContext.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            storeContext.Products.Add(product);
                        }

                        await storeContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(e, "An error occured during migration");
            }

        }
    }
}
