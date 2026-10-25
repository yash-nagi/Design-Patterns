public class SugarDecorator : ICoffee
{
    private readonly ICoffee _coffee;

    public SugarDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", Sugar";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 10; // Adding cost of sugar
    }
}