using Common.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Message.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Infrastrunture;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddMediator();
        services.AddDomainServices();
        services.AddMapper(); 
        services.AddSwaggers();
        services.AddEndpointsApiExplorer();
        services.AddSettingdServices(config);
        services.AddSerializer();
        services.AddServiceBusIntegrationConsumer(config);
    }

    public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwaggers(env);
        app.UseExceptionMiddleware();
        app.UseHttpsRedirection();
    }
}
