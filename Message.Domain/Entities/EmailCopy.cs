namespace Message.Domain.Entities;

public class EmailCopy : Email
{
    public string Cc { get; set; }
    public string Bcc { get; set; }
}
