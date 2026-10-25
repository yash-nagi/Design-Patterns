public interface IOrderItem
{
    decimal GetPrice();
    void DisplayDetails(int indentLevel);
}