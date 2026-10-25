public interface IFeeService
{
    bool CollectFees();
    decimal GetPendingFees();
}