public class UpiPayment : PaymentMode
{
    public override void MakePayment(decimal amount)
    {
        // Logic specific to UPI payment
        Console.WriteLine($"Making UPI payment of {amount}.");
        paymentGateway.ProcessPayment(amount);
    }
}