using Message.Infrastructure.AppSetting;
using Microsoft.Extensions.Options;
using Message.Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;

namespace Message.Infrastructure.Adapter;

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly EmailSettings _emailSettings;

    public EmailService(IOptions<EmailSettings> options)
    {
        _emailSettings = options.Value;
        _smtpClient = new SmtpClient();
        _smtpClient.Connect(_emailSettings.Host, _emailSettings.PortTLS, SecureSocketOptions.StartTls);
        _smtpClient.Authenticate(_emailSettings.Username, _emailSettings.Password);
    }

    public async Task SendEmail(Email request)
    {
        MimeMessage email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_emailSettings.Username));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        await _smtpClient.SendAsync(email);
        await _smtpClient.DisconnectAsync(true);
    }

    public async Task SendCopyEmail(EmailCopy request)
    {
        MimeMessage email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_emailSettings.Username));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Cc.Add(MailboxAddress.Parse(request.Cc));
        email.Bcc.Add(MailboxAddress.Parse(request.Bcc));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

        await _smtpClient.SendAsync(email);
        await _smtpClient.DisconnectAsync(true);
    }

    public async Task SendPriorityEmail(EmailPriority request)
    {
        MimeMessage email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_emailSettings.Username));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
        email.Priority = (MessagePriority)request.PriorityLevel;

        await _smtpClient.SendAsync(email);
        await _smtpClient.DisconnectAsync(true);
    }
}