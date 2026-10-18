public class SamsungPhone : IPhone
{
    public string Model => "Samsung Galaxy S23 Ultra";

    public void MakeCall()
    {
        Console.WriteLine($"Making a call using {Model}.");
    }
}