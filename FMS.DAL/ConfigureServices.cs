using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.DAL
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            services.AddDbContext<FMSContext>(o => o.UseInMemoryDatabase("FMSDb"));

            return services;
        }
    }
}
