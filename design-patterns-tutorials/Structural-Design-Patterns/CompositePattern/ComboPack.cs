public class ComboPack : IOrderItem
{
    public string Name { get; set; }
    public List<IOrderItem> Items { get; set; }

    public ComboPack(string name)
    {
        Name = name;
        Items = new List<IOrderItem>();
    }

    public void AddItem(IOrderItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(IOrderItem item)
    {
        Items.Remove(item);
    }
    public decimal GetPrice()
    {
        return Items.Sum(item => item.GetPrice());
    }

    public void DisplayDetails(int indentLevel)
    {
        Console.WriteLine($"{new string(' ', indentLevel * 2)}Combo Pack: {Name}, Total Price: {GetPrice()}");
        foreach (var item in Items)
        {
            item.DisplayDetails(indentLevel + 1);
        }
    }
}