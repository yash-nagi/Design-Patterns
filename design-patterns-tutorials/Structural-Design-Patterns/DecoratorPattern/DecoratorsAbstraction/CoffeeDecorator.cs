public abstract class CoffeeDecorator : ICoffee
{
    public ICoffee coffee;
    public virtual string GetDescription()
    {
        return coffee.GetDescription();
    }
    public virtual double GetCost()
    {
        return coffee.GetCost();
    }
}