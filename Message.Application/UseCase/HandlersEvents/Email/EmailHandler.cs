using Common.Communication.Consumer.Handler;
using Message.Infrastructure.Adapter;
using Common.Communication.Messages;
using Message.Domain.Entities;

namespace Message.Application.UseCase.HandlersEvents;

public class EmailHandler : IIntegrationMessageHandler<EmailCommand>
{
    private readonly IEmailService _emailServices;
    private readonly IMapper _mapper;

    public EmailHandler(IEmailService emailServices, IMapper mapper)
    {
        _emailServices = emailServices ?? throw new ArgumentNullException(nameof(emailServices));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Handle(IntegrationMessage<EmailCommand> request, CancellationToken cancelToken = default)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request.Content),
            "request object needed to handle this task");
        await _emailServices.SendEmail(_mapper.Map<Email>(request.Content));
    }
}