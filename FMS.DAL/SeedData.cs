using FMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS.DAL
{
    public static class SeedData
    {
        public static void Initialize(FMSContext context)
        {
            context.Database.EnsureCreated();

            var locationTypes = new LocationType[]
            {
                new LocationType { Code = "VL", Name = "Valmiskaubaladu" },
                new LocationType { Code = "KL", Name = "Komisjoniladu" },
                new LocationType { Code = "PL", Name = "Poeladu" }
            };
            context.AddRange(locationTypes);
            context.SaveChanges();

            // 12 locations
            var locations = new Location[]
            {
                new Location { LocationTypeId = 1, Code = "VL-EST", Name = "Eesti" },
                new Location { LocationTypeId = 1, Code = "VL-EKSP", Name = "Eksport" },
                new Location { LocationTypeId = 1, Code = "VL-NÄIDIS", Name = "Näidiste ladu" },
                new Location { LocationTypeId = 1, Code = "VL-KULTAK", Name = "Kultakeskus" },
                new Location { LocationTypeId = 1, Code = "VL-GENSE", Name = "Gense" },
                new Location { LocationTypeId = 1, Code = "VL-JUVSVE", Name = "Juveel Sverige" },
                new Location { LocationTypeId = 2, Code = "KL-LEVI", Name = "Levi Design" },
                new Location { LocationTypeId = 2, Code = "KL-INKUB", Name = "Tallinna Ettevõtlusinkubaatorid" },
                new Location { LocationTypeId = 3, Code = "PL-JUVÄRI", Name = "Juveeliäri" },
                new Location { LocationTypeId = 3, Code = "PL-JÄRVE", Name = "Firmakauplus Järve" },
                new Location { LocationTypeId = 3, Code = "PL-ROCCA", Name = "Firmakauplus Rocca al Mare" },
                new Location { LocationTypeId = 3, Code = "PL-KRISTI", Name = "Firmakauplus Kristiine" }
            };
            context.AddRange(locations);
            context.SaveChanges();

            // product source types
            var sourceType1 = new ProductSourceType { Name = "Toodang" };
            var sourceType2 = new ProductSourceType { Name = "Ost" };

            // product groups
            var group1 = new ProductGroup { Name = "Sõrmus" };
            var group2 = new ProductGroup { Name = "Kõrvarõngad" };
            var group3 = new ProductGroup { Name = "Ripats" };

            // 27 products
            var products = new Product[]
            {
                new Product { Code = "00020073", Name = "Sõrmus nat. safiir", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "00020282", Name = "Sõrmus naturaalne safiir, teemant", ProductSourceType = sourceType2, ProductGroup = group1 },
                new Product { Code = "00020355", Name = "Sõrmus naturaalne granaat", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "00020446", Name = "Sõrmus pärl valge", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "00020616", Name = "Sõrmus nat. granaat", ProductSourceType = sourceType2, ProductGroup = group1 },
                new Product { Code = "00020829", Name = "Sõrmus naturaalne granaat", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "00021477", Name = "Sõrmus valge pärl", ProductSourceType = sourceType2, ProductGroup = group1 },
                new Product { Code = "00021526", Name = "Sõrmus naturaalne smaragd", ProductSourceType = sourceType2, ProductGroup = group1 },
                new Product { Code = "00021679", Name = "Sõrmus nat. topaas", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "00022261", Name = "Sõrmus nat. granaat", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "03020916", Name = "Sõrmus sünt. aleksandriit", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "03021035", Name = "Sõrmus CZ must", ProductSourceType = sourceType2, ProductGroup = group1 },
                new Product { Code = "03021717", Name = "Sõrmus sünt. ametüst", ProductSourceType = sourceType2, ProductGroup = group1 },
                new Product { Code = "03022187", Name = "Sõrmus CZ", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "03022335", Name = "Sõrmus sünt. aleksandriit", ProductSourceType = sourceType1, ProductGroup = group1 },
                new Product { Code = "03030232", Name = "Kõrvarõngad CZ valge", ProductSourceType = sourceType2, ProductGroup = group2 },
                new Product { Code = "03030796", Name = "Kõrvarõngad CZ valge", ProductSourceType = sourceType2, ProductGroup = group2 },
                new Product { Code = "03031077", Name = "Kõrvarõngad CZ shampanja", ProductSourceType = sourceType1, ProductGroup = group2 },
                new Product { Code = "03031752", Name = "Kõrvarõngad CZ sampanja", ProductSourceType = sourceType1, ProductGroup = group2 },
                new Product { Code = "03031528", Name = "Kõrvarõngad CZ", ProductSourceType = sourceType2, ProductGroup = group2 },
                new Product { Code = "03090239", Name = "Ripats CZ sinine", ProductSourceType = sourceType2, ProductGroup = group3 },
                new Product { Code = "03090662", Name = "Ripats sünt. aleksandriit", ProductSourceType = sourceType1, ProductGroup = group3 },
                new Product { Code = "03090797", Name = "Ripats CZ valge", ProductSourceType = sourceType1, ProductGroup = group3 },
                new Product { Code = "03090820", Name = "Ripats CZ valge", ProductSourceType = sourceType1, ProductGroup = group3 },
                new Product { Code = "03092347", Name = "Ripats CZ lavender", ProductSourceType = sourceType2, ProductGroup = group3 },
                new Product { Code = "03092477", Name = "Ripats CZ", ProductSourceType = sourceType1, ProductGroup = group3 },
                new Product { Code = "03098704", Name = "Ripats Hobuseraud CZ", ProductSourceType = sourceType1, ProductGroup = group3 }
            };
            context.AddRange(products);
            context.SaveChanges();

            var random = new Random();

            // inventory
            var inventory = new List<Inventory>();
            foreach (var location in locations)
            {
                var productIds = Enumerable.Range(1, random.Next(1, 27));
                foreach (int productId in productIds)
                {
                    int stockQuantity = 0;
                    int reservedQuantity = 0;

                    if (random.Next(1, 10) < 7)
                    {
                        stockQuantity = random.Next(1, 10);

                        if (random.Next(1, 10) < 8)
                        {
                            reservedQuantity = (stockQuantity % 2) == 0 ? random.Next(1, stockQuantity) : 0;
                        }
                        else
                        {
                            reservedQuantity = stockQuantity;
                        }
                    }
                    
                    inventory.Add(new Inventory 
                    { 
                        LocationId = location.Id, 
                        ProductId = productId, 
                        StockQuantity = stockQuantity, 
                        ReservedQuantity = reservedQuantity 
                    });
                }
                
            }
            context.AddRange(inventory);
            context.SaveChanges();

            // 5 price lists
            var priceLists = new PriceList[]
            {
                new PriceList { Name = "Eesti", CurrencyCode = "EUR" },
                new PriceList { Name = "Eksport", CurrencyCode = "EUR" },
                new PriceList { Name = "Soome", CurrencyCode = "EUR" },
                new PriceList { Name = "Gense", CurrencyCode = "SEK" },
                new PriceList { Name = "Juveel Sverige", CurrencyCode = "SEK" },
            };
            context.AddRange(priceLists);
            context.SaveChanges();

            // prices
            var prices = new List<Price>();
            foreach (var priceList in priceLists)
            {
                foreach (var product in products)
                {
                    if (priceList.CurrencyCode == "EUR" || (priceList.CurrencyCode == "SEK" && random.Next(1, 10) < 6))
                    {
                        prices.Add(new Price
                        {
                            ProductId = product.Id,
                            PriceListId = priceList.Id,
                            UnitPrice = priceList.CurrencyCode == "EUR" ? random.Next(100, 400) : random.Next(1000, 5000)
                        });
                    }
                }
            }
            context.AddRange(prices);
            context.SaveChanges();
        }
    }
}
