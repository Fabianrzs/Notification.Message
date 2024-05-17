using Message.Domain.Entities;
using Reservar.Common.Domain.Entities.Subscription;

namespace Message.Application.UseCase.HandlersEvents;

public class DomainEventsProfile:Profile
{
    public DomainEventsProfile()
    {
        CreateMap<EmailCommand, Email>()
            .ReverseMap();
    }
}
