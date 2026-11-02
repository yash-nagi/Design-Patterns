public class BurgerkingBurger
{
    // Whopper, Big King, Double Whopper, etc.
    public string BurgerName { get; set; }
    // Cocacola, Pepsi, Sprite, Coffee, etc.
    public string Bavrages { get; set; }
    // Fries, Onion Rings, Nuggets, etc.
    public string SubordinateItems { get; set; }
    public void CreateBurger(string burgerName, string bavrages, string subordinateItems)
    {
        BurgerName = burgerName;
        Bavrages = bavrages;
        SubordinateItems = subordinateItems;
    }
    public void ShowBurgerDetails()
    {
        Console.WriteLine($"Burger Name: {BurgerName}");
        Console.WriteLine($"Bavrages: {Bavrages}");
        Console.WriteLine($"Subordinate Items: {SubordinateItems}");
    }
    public void AddOns(string sauceType, string suppliment, string pattyType)
    {
        Console.WriteLine($"Sauce Type: {sauceType}");
        Console.WriteLine($"Suppliment: {suppliment}");
        Console.WriteLine($"Patty Type: {pattyType}");
        ShowBurgerDetails();
    }
}