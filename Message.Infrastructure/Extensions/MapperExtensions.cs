using Booking.Infrastrunture;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Message.Infrastructure.Extensions;


public static class AutoMapperExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.Load(ApiConstants.ApplicationProject));
        return services;
    }
}