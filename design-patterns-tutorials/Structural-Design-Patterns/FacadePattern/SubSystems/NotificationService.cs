public class NotificationService : INotificationService
{
    public void SendEmailNotification()
    {
        Console.WriteLine("Email notification sent successfully.");
    }

    public void SendSMSNotification()
    {
        Console.WriteLine("SMS notification sent successfully.");
    }
}