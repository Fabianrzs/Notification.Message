using Booking.Infrastrunture.Middlewares;
using Message.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Message.Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static void UseExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }

    public static void UseMediatorMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<MediatrLoggingMiddleware>();
    }
}
