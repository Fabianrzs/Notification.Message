using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Message.Infrastructure.Middlewares;

public class MediatrLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<MediatrLoggingMiddleware> _logger;

    public MediatrLoggingMiddleware(RequestDelegate next, ILogger<MediatrLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context, IMediator mediator)
    {
        var requestBody = await ReadRequestBodyAsync(context.Request);
        _logger.LogInformation($"MediatR Request: {requestBody}");
        await _next(context);
        var responseBody = await ReadResponseBodyAsync(context.Response);
        _logger.LogInformation($"MediatR Response: {responseBody}");
    }

    private async Task<string> ReadRequestBodyAsync(HttpRequest request)
    {
        request.EnableBuffering();

        using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;

        return body;
    }

    private async Task<string> ReadResponseBodyAsync(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var body = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return body;
    }
}