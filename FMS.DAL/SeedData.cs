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
                new Location { LocationTypeId = 3, Code = "PL-KRISTE", Name = "Firmakauplus Kristiine" }
            };
            context.AddRange(locations);
            context.SaveChanges();

            // 27 products
            var products = new Product[]
            {
                new Product { Code = "00020073", Name = ""},
                new Product { Code = "00020282", Name = ""},
                new Product { Code = "00020355", Name = ""},
                new Product { Code = "00020446", Name = ""},
                new Product { Code = "00020616", Name = ""},
                new Product { Code = "00020829", Name = ""},
                new Product { Code = "00021477", Name = ""},
                new Product { Code = "00021526", Name = ""},
                new Product { Code = "00021679", Name = ""},
                new Product { Code = "00022261", Name = ""},
                new Product { Code = "03020916", Name = ""},
                new Product { Code = "03021035", Name = ""},
                new Product { Code = "03021717", Name = ""},
                new Product { Code = "03022187", Name = ""},
                new Product { Code = "03022335", Name = ""},
                new Product { Code = "03030232", Name = ""},
                new Product { Code = "03030796", Name = ""},
                new Product { Code = "03031077", Name = ""},
                new Product { Code = "03031752", Name = ""},
                new Product { Code = "03031528", Name = ""},
                new Product { Code = "03090239", Name = ""},
                new Product { Code = "03090662", Name = ""},
                new Product { Code = "03090797", Name = ""},
                new Product { Code = "03090820", Name = ""},
                new Product { Code = "03092347", Name = ""},
                new Product { Code = "03092477", Name = ""},
                new Product { Code = "03098704", Name = ""}
            };
            context.AddRange(products);
            context.SaveChanges();

            var inventory = new List<Inventory>();
            var random = new Random();
            foreach (var location in locations)
            {
                var productIds = Enumerable.Range(1, random.Next(1, 27));
                foreach (int productId in productIds)
                {
                    int stockQuantity = random.Next(1, 10);
                    int reservedQuantity = (stockQuantity % 2) == 0 ? random.Next(1, stockQuantity) : 0;
                    
                    inventory.Add(new Inventory 
                    { 
                        LocationId = location.Id, 
                        ProductId = productId, 
                        StockQuantity = stockQuantity, 
                        ReservedQuantity = reservedQuantity 
                    });
                }
                
            }
        }
    }
}
