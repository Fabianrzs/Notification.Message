using Common.Communication.Consumer.Handler;
using Common.Communication.Messages;
using Common.Communication.RabbitMQ.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Infrastructure.Extensions;

public static class BusExtensions
{
    public static void AddServiceBusIntegrationConsumer(this IServiceCollection serviceCollection,
       IConfiguration configuration)
    {
        serviceCollection.AddRabbitMQ(configuration);
        serviceCollection.AddRabbitMqConsumer<IntegrationMessage>();
    }

    public static void AddHandlersInAssembly<T>(this IServiceCollection serviceCollection)
    {
        serviceCollection.Scan(scan => scan.FromAssemblyOf<T>()
            .AddClasses(classes => classes.AssignableTo<IMessageHandler>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        ServiceProvider sp = serviceCollection.BuildServiceProvider();
        var listHandlers = sp.GetServices<IMessageHandler>();
        serviceCollection.AddConsumerHandlers(listHandlers);
    }
}
