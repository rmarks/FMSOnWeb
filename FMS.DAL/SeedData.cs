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

            var random = new Random();

            #region products module
            // product statuses
            var status1 = new ProductStatus { Name = "Aktiivne" };
            var status2 = new ProductStatus { Name = "Lõpetatud" };

            // product materials
            var material1 = new ProductMaterial { Name = "Kuld" };
            var material2 = new ProductMaterial { Name = "Hõbe" };

            // product source types
            var sourceType1 = new ProductSourceType { Name = "Toodang" };
            var sourceType2 = new ProductSourceType { Name = "Ost" };

            // product destination types
            var destType1 = new ProductDestinationType { Name = "Sortiment" };
            var destType2 = new ProductDestinationType { Name = "Allhange" };
            var destType3 = new ProductDestinationType { Name = "Eritellimus" };

            // product types
            var productTypes = new ProductType[]
            {
                new ProductType { Name = "Ehted" },
                new ProductType { Name = "Lauariistad" },
                new ProductType { Name = "Lauanõud" }
            };
            context.AddRange(productTypes);
            context.SaveChanges();

            // product groups
            var group1 = new ProductGroup { Name = "Sõrmus", ProductTypeId = 1 };
            var group2 = new ProductGroup { Name = "Kõrvarõngad", ProductTypeId = 1 };
            var group3 = new ProductGroup { Name = "Ripats", ProductTypeId = 1 };
            var productGroups = new ProductGroup[]
            {
                group1,
                group2,
                group3,
                new ProductGroup { Name = "Lauanuga", ProductTypeId = 2 },
                new ProductGroup { Name = "Lauakahvel", ProductTypeId = 2},
                new ProductGroup { Name = "Küünlajalg", ProductTypeId = 3},
                new ProductGroup { Name = "Konjakipokaal", ProductTypeId = 3}
            };
            context.AddRange(productGroups);
            context.SaveChanges();

            // product brands
            var productBrands = new ProductBrand[]
            {
                new ProductBrand { Name = "Lummus" },
                new ProductBrand { Name = "Juveel teemant "},
                new ProductBrand { Name = "Kohinoor"}
            };
            context.AddRange(productBrands);
            context.SaveChanges();

            // product collections
            var productCollections = new ProductCollection[]
            {
                new ProductCollection { Name = "Aastasada", ProductBrandId = 1},
                new ProductCollection { Name = "Aovalgus", ProductBrandId = 1},
                new ProductCollection { Name = "Võsailu", ProductBrandId = 1}
            };
            context.AddRange(productCollections);
            context.SaveChanges();

            // product variant types
            var variantTypeRing = new ProductVariantType { Name = "Sõrmuse suurus" };
            var variantTypes = new ProductVariantType[]
            {
                variantTypeRing,
                new ProductVariantType { Name = "Kaelaketi pikkus" },
                new ProductVariantType { Name = "Käeketi pikkus" }
            };
            context.AddRange(variantTypes);
            context.SaveChanges();

            // product variants
            var variants = new ProductVariant[]
            {
                new ProductVariant { Code = "165", Name = "suurus 16,5", ProductVariantType = variantTypeRing },
                new ProductVariant { Code = "170", Name = "suurus 17,0", ProductVariantType = variantTypeRing },
                new ProductVariant { Code = "175", Name = "suurus 17,5", ProductVariantType = variantTypeRing },
                new ProductVariant { Code = "190", Name = "suurus 19,0", ProductVariantType = variantTypeRing },
            };
            context.AddRange(variants);
            context.SaveChanges();

            // 27 product bases
            var productBases = new ProductBase[]
            {
                new ProductBase { Code = "00020073", Name = "Sõrmus nat. safiir", ProductStatus = status1, ProductMaterial = material1, 
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00020282", Name = "Sõrmus naturaalne safiir, teemant", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType2, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00020355", Name = "Sõrmus naturaalne granaat", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00020446", Name = "Sõrmus pärl valge", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 3, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00020616", Name = "Sõrmus nat. granaat", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00020829", Name = "Sõrmus naturaalne granaat", ProductStatus = status2, ProductMaterial = material2,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00021477", Name = "Sõrmus valge pärl", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 3, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00021526", Name = "Sõrmus naturaalne smaragd", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00021679", Name = "Sõrmus nat. topaas", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "00022261", Name = "Sõrmus nat. granaat", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType3, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 2, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "03020916", Name = "Sõrmus sünt. aleksandriit", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 1, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "03021035", Name = "Sõrmus CZ must", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 3, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "03021717", Name = "Sõrmus sünt. ametüst", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType2, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 1, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "03022187", Name = "Sõrmus CZ", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 3, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "03022335", Name = "Sõrmus sünt. aleksandriit", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group1.ProductTypeId, ProductGroup = group1,
                    ProductBrandId = 1, ProductCollectionId = 1, ProductVariantType = variantTypeRing },
                new ProductBase { Code = "03030232", Name = "Kõrvarõngad CZ valge", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType3, ProductTypeId = group2.ProductTypeId, ProductGroup = group2,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03030796", Name = "Kõrvarõngad CZ valge", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType1, ProductTypeId = group2.ProductTypeId, ProductGroup = group2,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03031077", Name = "Kõrvarõngad CZ shampanja", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group2.ProductTypeId, ProductGroup = group2,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03031752", Name = "Kõrvarõngad CZ sampanja", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group2.ProductTypeId, ProductGroup = group2,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03031528", Name = "Kõrvarõngad CZ", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType1, ProductTypeId = group2.ProductTypeId, ProductGroup = group2,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03090239", Name = "Ripats CZ sinine", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType2, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03090662", Name = "Ripats sünt. aleksandriit", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 1, ProductCollectionId = 1 },
                new ProductBase { Code = "03090797", Name = "Ripats CZ valge", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03090820", Name = "Ripats CZ valge", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03092347", Name = "Ripats CZ lavender", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType2, ProductDestinationType = destType2, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03092477", Name = "Ripats CZ", ProductStatus = status2, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 3 },
                new ProductBase { Code = "03098704", Name = "Ripats Hobuseraud CZ", ProductStatus = status1, ProductMaterial = material1,
                    ProductSourceType = sourceType1, ProductDestinationType = destType1, ProductTypeId = group3.ProductTypeId, ProductGroup = group3,
                    ProductBrandId = 3 }
            };
            context.AddRange(productBases);
            context.SaveChanges();

            // products
            var products = new List<Product>();
            foreach (var pb in productBases)
            {
                if (pb.ProductVariantTypeId is null)
                {
                    products.Add(new Product { Code = pb.Code, Name = pb.Name, ProductBaseId = pb.Id });
                }
                else
                {
                    foreach (var pv in variants)
                    {
                        if (random.Next(0, 3) == 0)
                        {
                            continue;
                        }

                        products.Add(new Product
                        {
                            Code = $"{pb.Code}-{pv.Code}",
                            Name = $"{pb.Name} {pv.Name}",
                            ProductBaseId = pb.Id,
                            ProductVariantId = pv.Id
                        });
                    }
                }
            }
            context.AddRange(products);
            context.SaveChanges();
            #endregion

            #region prices module
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
            #endregion

            #region locations and inventory module
            // location types
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

            // inventory
            var inventory = new List<Inventory>();
            foreach (var location in locations)
            {
                var productIds = Enumerable.Range(1, random.Next(1, products.Count + 1));
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
            #endregion
        }
    }
}
