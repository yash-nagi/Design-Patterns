public class EmailMessage
{
    private readonly string to;
    private readonly string from;
    private readonly string subject;
    private readonly string body;
    private readonly List<string> attachments;
    private readonly string cc;
    private readonly string bcc;
    public EmailMessage(EmailMessageBuilder builder)
    {
        this.to = builder.GetTo();
        this.from = builder.GetFrom();
        this.subject = builder.GetSubject();
        this.body = builder.GetBody();
        this.attachments = builder.GetAttachments();
        this.cc = builder.GetCc();
        this.bcc = builder.GetBcc();
    }
    public string GetTo() => to;
    public string GetFrom() => from;
    public string GetSubject() => subject;
    public string GetBody() => body;
    public List<string> GetAttachments() => attachments;
    public string GetCc() => cc;
    public string GetBcc() => bcc;
    public void DisplayEmail()
    {
        Console.WriteLine($"To: {to}");
        Console.WriteLine($"From: {from}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Body: {body}");
        if (attachments.Count > 0)
        {
            Console.WriteLine("Attachments:");
            foreach (var attachment in attachments)
            {
                Console.WriteLine($"- {attachment}");
            }
        }
        if (!string.IsNullOrEmpty(cc))
        {
            Console.WriteLine($"CC: {cc}");
        }
        if (!string.IsNullOrEmpty(bcc))
        {
            Console.WriteLine($"BCC: {bcc}");
        }
    }
}