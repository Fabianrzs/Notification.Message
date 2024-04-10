using Message.Domain.Entities;
using Message.Infrastructure.Adapter;

namespace Message.Application.UseCase.DomainEvents;

public class EmailCreateHandler : IRequestHandler<EmailCreateCommand, string>
{
    private readonly IEmailService _emailServices;
    private readonly IMapper _mapper;

    public EmailCreateHandler(IEmailService emailServices, IMapper mapper)
    {
        _emailServices = emailServices ?? throw new ArgumentNullException(nameof(emailServices));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<string> Handle(EmailCreateCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request), 
            "request object needed to handle this task");
        await _emailServices.SendEmail(_mapper.Map<Email>(request));   
        return "Send Email";
    }
}