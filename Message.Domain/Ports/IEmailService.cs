using Message.Domain.Entities;

namespace Message.Infrastructure.Adapter;

public interface IEmailService
{
    public Task SendEmail(Email request);
    public Task SendCopyEmail(EmailCopy request);
    public Task SendPriorityEmail(EmailPriority request);
}
