public class CreamDecorator : CoffeeDecorator
{
    public CreamDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public override string GetDescription()
    {
        return coffee.GetDescription() + ", Cream";
    }

    public override double GetCost()
    {
        return coffee.GetCost() + 70;
    }
}