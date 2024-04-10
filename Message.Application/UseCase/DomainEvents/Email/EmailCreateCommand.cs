namespace Message.Application.UseCase.DomainEvents;

public record EmailCreateCommand(
    string To,
    string Subject,
    string Body,
    List<string>? Attachments
) : IRequest<string>;
