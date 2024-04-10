using Message.Application.UseCase.HandlersEvents;
using Message.Application.UseCase.DomainEvents;
using Common.Communication.Consumer.Manager;
using Message.Infrastructure.Extensions;
using Common.Communication.Messages;
using Message.Infrastrunture;
using Common.Serialization;
using MediatR;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSerializer();
//builder.Services.AddServiceBusIntegrationConsumer(builder.Configuration);
//builder.Services.AddHandlersInAssembly<EmailHandler>();

var app = builder.Build();
app.UseInfrastructure(app.Environment);

//var subscribe = app.Services.GetRequiredService<IMessageConsumer<IntegrationMessage>>();
//await subscribe.StartAsync();

app.MapPost("/Send", async (EmailCreateCommand emailDto) =>
{
    var _mediator = app.Services.GetRequiredService<IMediator>();
    return await _mediator.Send(emailDto);
})
.WithName("Email")
.WithOpenApi();

app.Run();
public partial class Program { }