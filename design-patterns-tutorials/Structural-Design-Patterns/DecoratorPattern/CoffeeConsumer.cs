public class CoffeeConsumer()
{
    public static void OrderCofee()
    {
        ICoffee coffee = new Coffee();
        Console.WriteLine("Description: " + coffee.GetDescription() + " Cost: " + coffee.GetCost());

        coffee = new MilkDecorator(coffee);
        Console.WriteLine("Description: " + coffee.GetDescription() + " Cost: " + coffee.GetCost());

        coffee = new CreamDecorator(coffee);
        Console.WriteLine("Description: " + coffee.GetDescription() + " Cost: " + coffee.GetCost());

        coffee = new SugarDecorator(coffee);
        Console.WriteLine("Description: " + coffee.GetDescription() + " Cost: " + coffee.GetCost());
    }
}