public class EmailNotification : INotification
{
    public void Notify(string message)
    {
        // Implementation for sending email notification
        Console.WriteLine($"Email Notification: {message}");
    }
}