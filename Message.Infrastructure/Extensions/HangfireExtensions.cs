using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Infrastructure.Extensions;

public static class HangfireExtensions
{
    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration config)
    {

        //services.AddHangfire(configuration => configuration
        //        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        //        .UseSimpleAssemblyNameTypeSerializer()
        //        .UseRecommendedSerializerSettings()
        //        .UseSqlServerStorage(config.GetConnectionString("HangfireConnection")));

        //services.AddHangfireServer();

        return services;
    }
}
