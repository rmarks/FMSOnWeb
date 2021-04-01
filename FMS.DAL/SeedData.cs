using FMS.Domain.Models;

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
        }
    }
}
