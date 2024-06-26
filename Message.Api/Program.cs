using Message.Application.UseCase.DomainEvents;
using Common.Communication.Consumer.Manager;
using Common.Communication.Messages;
using Message.Infrastrunture;
using MediatR;
using Message.Application.UseCase.HandlersEvents;
using Message.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHandlersInAssembly<EmailHandler>();
var app = builder.Build();
app.UseInfrastructure(app.Environment);

app.MapPost("/Send", async (EmailCreateCommand emailDto) =>
{
    var _mediator = app.Services.GetRequiredService<IMediator>();
    return await _mediator.Send(emailDto);
})
.WithName("Email")
.WithOpenApi();

app.MapPut("/Start", (IConsumerManager<IntegrationMessage> consumerManager) =>
{
    consumerManager.RestartExecution();
    return Results.Ok();
})
.WithName("Integration")
.WithOpenApi();

app.Run();
public partial class Program { }

