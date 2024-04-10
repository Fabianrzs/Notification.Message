using Microsoft.Extensions.DependencyInjection;
using Booking.Infrastrunture;
using System.Reflection;
using MediatR;
namespace Message.Infrastructure.Extensions;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.Load(ApiConstants.ApplicationProject), Assembly.GetExecutingAssembly());
        return services;
    }
}
