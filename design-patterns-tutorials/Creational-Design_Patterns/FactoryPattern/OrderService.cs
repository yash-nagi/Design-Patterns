class OrderService
{
    public void SendNotification()
    {
        INotification notification = NotificationFactory.CreateNotification("Email");
        notification.Notify("Your order has been confirmed.");
    }
}