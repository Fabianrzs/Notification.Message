namespace Message.Application.UseCase.HandlersEvents;

public record EmailCommand(
    string To,
    string Subject,
    string Body,
    List<string>? Attachments
);
