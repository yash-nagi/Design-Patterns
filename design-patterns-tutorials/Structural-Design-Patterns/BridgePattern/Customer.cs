public class Customer
{
    public static void MakePayment(string paymentGateway, decimal amount, string paymentMode)
    {
        PaymentMode mode = paymentMode switch
        {
            "CreditCard" => new CreditCardPayment(),
            "DebitCard" => new DebitCardPayment(),
            "NetBanking" => new NetBankingPayment(),
            "UPI" => new UpiPayment(),
            _ => throw new ArgumentException("Invalid payment mode")
        };
        mode.paymentGateway = paymentGateway switch
        {
            "HDFC" => new HDFCBankPaymentGateway(),
            "SBI" => new SBIPaymentGateway(),
            "Axis" => new AxisBankPaymentGateway(),
            "UnionBank" => new UnionBankPaymentGateway(),
            _ => throw new ArgumentException("Invalid payment gateway")
        };
        mode.MakePayment(amount);
    }



}