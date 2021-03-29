using FMS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.DAL
{
    public class FMSContext : DbContext
    {
        public FMSContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
    }
}
