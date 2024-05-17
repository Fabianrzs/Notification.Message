using Common.Communication.Consumer.Handler;
using Message.Infrastructure.Adapter;
using Common.Communication.Messages;
using Message.Domain.Entities;
using Reservar.Common.Domain.Entities.Subscription;
using Message.Application.UseCase.DomainEvents;

namespace Message.Application.UseCase.HandlersEvents;

public class EmailHandler : IRequestHandler<EmailCommand>
{
    private readonly IEmailService _emailServices;
    private readonly IMapper _mapper;

    public EmailHandler(IEmailService emailServices, IMapper mapper)
    {
        _emailServices = emailServices ?? throw new ArgumentNullException(nameof(emailServices));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Unit> Handle(EmailCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request),
                    "request object needed to handle this task");
        await _emailServices.SendEmail(_mapper.Map<Email>(request));
        return Unit.Value;
    }
}