
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

// Bridge Design Pattern
Customer.MakePayment(paymentGateway: "HDFC", paymentMode: "CreditCard", amount: 1000);
Customer.MakePayment(paymentGateway: "Axis", paymentMode: "DebitCard", amount: 2390);

// Composite Design Pattern
ShoppingCart.CheckOut();

// Decorator Design Pattern
CoffeeConsumer.OrderCofee();

// Facade Design Pattern
StudentPortal.ExploreServices();

// Flyweight Design Pattern
BurgerkingFactory burgerFactory = new BurgerkingFactory();
BurgerkingBurger burger1 = burgerFactory.CreateBurger("Whopper", "Cocacola", "Fries");
BurgerkingBurger burger2 = burgerFactory.CreateBurger("Whopper", "Cocacola", "Fries");
Console.WriteLine("Burger 1");
burger1.AddOns("Ketchup", "Cheese", "Beef");
Console.WriteLine("Burger 2");
burger2.AddOns("Mustard", "Bacon", "Chicken");

// Proxy Design Pattern
ProxyDatabase proxyDatabase = new ProxyDatabase();
proxyDatabase.LogIn();
Console.WriteLine(proxyDatabase.GetDataForId(1));
proxyDatabase.LogOut();
Console.WriteLine(proxyDatabase.GetDataForId(1));

// Behavioral Design Patterns: Behavioral design patterns are used to manage algorithms, relationships, and responsibilities between objects.
// Chain of Responsibility Design Pattern
User user = new User(new Chatbot(new SupportExecutive(new TechTeam())));
user.RaiseIssue(new Issue("Migration failed", "LEVEL3", "PENDING"));
