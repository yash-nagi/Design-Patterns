public class AxisBankPaymentGateway : IPaymentGateWay
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process payment through Axis Bank's payment gateway
        Console.WriteLine($"Processing payment of {amount} through Axis Bank Payment Gateway.");
    }
}