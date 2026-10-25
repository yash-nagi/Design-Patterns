public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Milk";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 50;
    }
}