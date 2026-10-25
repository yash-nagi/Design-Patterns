public abstract class PaymentMode
{
    public IPaymentGateWay paymentGateway;
    public abstract void MakePayment(decimal amount);
}