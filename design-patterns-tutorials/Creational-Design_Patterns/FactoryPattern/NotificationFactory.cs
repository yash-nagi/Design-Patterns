public class NotificationFactory
{
    public static INotification CreateNotification(string type)
    {
        return type switch
        {
            "SMS" => new SmsNotification(),
            "Email" => new EmailNotification(),
            _ => throw new ArgumentException("Invalid notification type")
        };
    }
}