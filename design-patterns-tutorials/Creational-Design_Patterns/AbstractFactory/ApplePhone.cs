public class ApplePhone : IPhone
{
    public string Model => "iPhone 18 Pro Max";

    public void MakeCall()
    {
        Console.WriteLine($"Making a call using {Model}.");
    }
}