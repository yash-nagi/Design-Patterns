public class ShoppingCart
{
    public static void CheckOut()
    {
        ComboPack orderItem = new ComboPack("Laptop Combo");
        orderItem.AddItem(new Product("Lenovo ThinkPad", 80000));
        orderItem.AddItem(new Product("Lenovo ThinkPad Charger", 2000));
        orderItem.AddItem(new Product("Lenovo Laptop Bag", 1500));

        ComboPack orderItem2 = new ComboPack("Mobile Combo");
        orderItem2.AddItem(new Product("Samsung Galaxy S21", 70000));
        orderItem2.AddItem(new Product("Samsung Galaxy S21 Charger", 70000));
        orderItem2.AddItem(new Product("Samsung Earbuds", 70000));
        orderItem2.AddItem(orderItem);

        orderItem2.DisplayDetails(indentLevel: 0);
        Console.WriteLine($"Total Price: {orderItem2.GetPrice()}");

    }
}