using Message.Domain.Entities;

namespace Message.Application.UseCase.DomainEvents;

public class DomainEventsProfile:Profile
{
    public DomainEventsProfile()
    {
        CreateMap<EmailCreateCommand, Email>()
            .ReverseMap();
    }
}
