public class DebitCardPayment : PaymentMode
{
    public override void MakePayment(decimal amount)
    {
        // Logic specific to debit card payment
        Console.WriteLine($"Making debit card payment of {amount}.");
        paymentGateway.ProcessPayment(amount);
    }
}