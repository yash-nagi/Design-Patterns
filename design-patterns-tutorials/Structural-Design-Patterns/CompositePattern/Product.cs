public class Product : IOrderItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public decimal GetPrice()
    {
        return Price;
    }

    public void DisplayDetails(int indentLevel)
    {
        Console.WriteLine($"{new string(' ', indentLevel * 2)}Product: {Name}, Price: {Price}");
    }
}