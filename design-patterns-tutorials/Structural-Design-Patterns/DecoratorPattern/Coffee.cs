public class Coffee : ICoffee
{
    public string GetDescription()
    {
        return "Coffee";
    }

    public double GetCost()
    {
        return 100;
    }
}