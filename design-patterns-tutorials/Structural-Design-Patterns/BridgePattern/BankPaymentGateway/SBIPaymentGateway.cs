public class SBIPaymentGateway : IPaymentGateWay
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process payment through SBI Bank's payment gateway
        Console.WriteLine($"Processing payment of {amount} through SBI Bank Payment Gateway.");
    }
}