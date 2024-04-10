using Message.Infrastructure.Adapter;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Message.Infrastructure.Extensions
{

    public static class ServiceExtensions {
        public static IServiceCollection AddDomainServices(this IServiceCollection svc)
        {
            svc.AddTransient<IEmailService, EmailService>();
            return svc;
        }
    }
}
