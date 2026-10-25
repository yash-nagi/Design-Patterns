public class UnionBankPaymentGateway : IPaymentGateWay
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process payment through Union Bank's payment gateway
        Console.WriteLine($"Processing payment of {amount} through Union Bank Payment Gateway.");
    }
}