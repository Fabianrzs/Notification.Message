using Message.Domain.Entities;

namespace Message.Application.UseCase.HandlersEvents;

public class DomainEventsProfile:Profile
{
    public DomainEventsProfile()
    {
        CreateMap<EmailCommand, Email>()
            .ReverseMap();
    }
}
