public class EmailMessageBuilder
{
    private string to;
    private string from;
    private string subject;
    private string body;
    private List<string> attachments = new List<string>();
    private string cc;
    private string bcc;

    public EmailMessageBuilder SetTo(string to)
    {
        this.to = to;
        return this;
    }

    public EmailMessageBuilder SetFrom(string from)
    {
        this.from = from;
        return this;
    }

    public EmailMessageBuilder SetSubject(string subject)
    {
        this.subject = subject;
        return this;
    }

    public EmailMessageBuilder SetBody(string body)
    {
        this.body = body;
        return this;
    }

    public EmailMessageBuilder AddAttachment(string attachment)
    {
        this.attachments.Add(attachment);
        return this;
    }

    public EmailMessageBuilder SetCc(string cc)
    {
        this.cc = cc;
        return this;
    }

    public EmailMessageBuilder SetBcc(string bcc)
    {
        this.bcc = bcc;
        return this;
    }
    public string GetTo() => to;
    public string GetFrom() => from;
    public string GetSubject() => subject;
    public string GetBody() => body;
    public List<string> GetAttachments() => attachments;
    public string GetCc() => cc;
    public string GetBcc() => bcc;

    public EmailMessage Build()
    {
        return new EmailMessage(builder: this);
    }
}