public class SamsungWatch : IWatch
{
    public string Model => "Samsung Galaxy Watch 6";

    public void Track()
    {
        Console.WriteLine($"Tracking health metrics using {Model}.");
    }
}