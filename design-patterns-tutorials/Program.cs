
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