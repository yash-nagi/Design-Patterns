public class NetBankingPayment : PaymentMode
{
    public override void MakePayment(decimal amount)
    {
        // Logic specific to net banking payment
        Console.WriteLine($"Making net banking payment of {amount}.");
        paymentGateway.ProcessPayment(amount);
    }
}