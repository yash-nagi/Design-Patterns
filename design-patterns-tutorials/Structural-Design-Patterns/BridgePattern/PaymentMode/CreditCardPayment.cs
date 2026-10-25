public class CreditCardPayment : PaymentMode
{

    public override void MakePayment(decimal amount)
    {
        // Logic specific to credit card payment
        Console.WriteLine($"Making credit card payment of {amount}.");
        paymentGateway.ProcessPayment(amount);
    }
}