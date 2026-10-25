public class HDFCBankPaymentGateway : IPaymentGateWay
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process payment through HDFC Bank's payment gateway
        Console.WriteLine($"Processing payment of {amount} through HDFC Bank Payment Gateway.");
    }
}