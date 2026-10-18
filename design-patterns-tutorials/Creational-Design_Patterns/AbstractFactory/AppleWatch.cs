public class AppleWatch : IWatch
{
    public string Model => "Apple Watch Series 9";

    public void Track()
    {
        Console.WriteLine($"Tracking health metrics using {Model}.");
    }
}