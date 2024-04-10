using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FMS.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddDAL();
        
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
