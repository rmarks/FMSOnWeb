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
                new LocationType { Code = "PO", Name = "Pood" }
            };
            context.AddRange(locationTypes);
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location { LocationTypeId = 1, Name = "Eesti" },
                new Location { LocationTypeId = 1, Name = "Eksport" },
                new Location { LocationTypeId = 1, Name = "Näidiste ladu" },
                new Location { LocationTypeId = 1, Name = "Kultakeskus" },
                new Location { LocationTypeId = 1, Name = "Gense" },
                new Location { LocationTypeId = 1, Name = "Juveel Sverige" },
                new Location { LocationTypeId = 2, Name = "Levi Design" },
                new Location { LocationTypeId = 2, Name = "Tallinna Ettevõtlusinkubaatorid" },
                new Location { LocationTypeId = 3, Name = "Juveeliäri" },
                new Location { LocationTypeId = 3, Name = "Firmakauplus Järve" },
                new Location { LocationTypeId = 3, Name = "Firmakauplus Rocca al Mare" },
                new Location { LocationTypeId = 3, Name = "Firmakauplus Kristiine" }
            };
            context.AddRange(locations);
            context.SaveChanges();
        }
    }
}
