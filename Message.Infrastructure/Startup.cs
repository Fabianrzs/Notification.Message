using Hangfire;
using Common.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Common.Communication.Messages;
using Message.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Common.Communication.Consumer.Manager;
using Microsoft.Extensions.DependencyInjection;
using Common.Communication.RabbitMQ.Consumer;

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
        //services.AddHangfire(config);
    }

    public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment env)
    {


        app.ApplicationServices.GetRequiredService<IMessageConsumer<IntegrationMessage>>();
        //IBackgroundJobClient backgroundJobs = app.ApplicationServices.GetRequiredService<IBackgroundJobClient>();
        

        //app.UseHangfireDashboard();
        //app.UseHangfireDashboard("/dashboard");
        
        //RecurringJob.AddOrUpdate("testconsole", () => Console.WriteLine("Simple!"), "* * * * 5 ");
        //RecurringJob.AddOrUpdate<RabbitMQMessageConsumer<IntegrationMessage>>("sender email", x => x.StartAsync(default), "*/5 * * * *");
        app.UseSwaggers(env);
        app.UseExceptionMiddleware();
        app.UseHttpsRedirection();
    }

    
}
