
/* Creational Design Patterns: Creational design patterns are used  to create instances of an objects.*/

// Singleton Design Pattern
LogService.Instance.Log("This is a log message.");

// Factory Design Pattern
OrderService orderService = new OrderService();
orderService.SendNotification();

// Abstract Factory Design Pattern
IosUser iosUser = new IosUser();
iosUser.BuyIosProducts();

AndroidUser androidUser = new AndroidUser();
androidUser.BuyAndroidProducts();

// Builder design pattern
Client client = new Client();
client.GenerateEmail();

// Prototype Design Pattern
CreateDatabaseConnection createConnection = new CreateDatabaseConnection();
var connections = createConnection.CreateConnection();
foreach (var connection in connections)
{
    Console.WriteLine($"Connection String: {connection.GetConnectionString()}");
}

// Structureal Design Patterns: Structural design patterns are used to create relationships between objects.
// Adapter Design Pattern
Application.DisplayEmployeeDetails();