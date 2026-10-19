public class Client
{
    public void GenerateEmail()
    {
        var builder = new EmailMessageBuilder()
            .SetTo("recipient@example.com")
            .SetFrom("sender@example.com")
            .SetSubject("Test Email")
            .SetBody("This is a test email.")
            .Build();
        builder.DisplayEmail();
    }
}