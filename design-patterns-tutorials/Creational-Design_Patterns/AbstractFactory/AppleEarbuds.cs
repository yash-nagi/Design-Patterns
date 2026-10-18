public class AppleEarbuds : IEarbuds
{
    public string Model => "Apple AirPods Pro 2";

    public void PlayMusic()
    {
        Console.WriteLine($"Playing music using {Model}.");
    }
}