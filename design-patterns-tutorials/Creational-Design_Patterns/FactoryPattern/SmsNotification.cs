public class SmsNotification : INotification
{
    public void Notify(string message)
    {
        // Implementation for sending SMS notification
        Console.WriteLine($"SMS Notification: {message}");
    }
}