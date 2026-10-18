public class SamsungEarbuds : IEarbuds
{
    public string Model => "Samsung Galaxy Buds 2 Pro";

    public void PlayMusic()
    {
        Console.WriteLine($"Playing music using {Model}.");
    }
}