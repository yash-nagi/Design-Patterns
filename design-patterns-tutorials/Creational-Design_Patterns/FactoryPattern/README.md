# 🏭 Factory Pattern: Notifications

## 🧩 What Is the Factory Pattern?

A factory centralizes the creation of objects behind a method or interface. Instead of having application code construct concrete classes directly, it asks the factory for an object and works with the abstraction that object implements.

This directory demonstrates the **Simple Factory** form: `NotificationFactory` examines a selection value and returns an implementation of `INotification`. Simple Factory is a commonly used pattern, but it is not the GoF **Factory Method** pattern, which delegates object creation to overridable methods in creator subclasses.

## ⚙️ How This Example Works

- `INotification` defines the common `Notify(string message)` operation.
- `EmailNotification` and `SmsNotification` implement that contract. In this tutorial, they simulate sending by writing a message to the console.
- `NotificationFactory.CreateNotification(string type)` creates and returns the selected implementation. It accepts the exact values `"Email"` and `"SMS"`; any other value throws `ArgumentException`.
- `OrderService.SendNotification()` asks the factory for an email notification, then calls `Notify` without needing to construct or otherwise depend on `EmailNotification` directly.

The flow is:

```text
OrderService -> NotificationFactory -> EmailNotification or SmsNotification
      |                                           |
      +---------- uses INotification ------------+
```

`OrderService` currently hardcodes `"Email"`, so this example demonstrates centralized creation, but not selection based on runtime user preferences.

## 🤔 Why Use a Factory?

Object creation can involve choosing among implementations, applying configuration, or coordinating setup. When clients each make that choice themselves, creation rules become duplicated and clients become coupled to concrete classes. A factory gives creation a single home and lets client code focus on using the returned object.

## ✨ Benefits

- 🔗 **Reduced coupling:** consumers can depend on `INotification` instead of concrete notification classes.
- 📍 **Centralized creation rules:** the mapping from a selection to an implementation is in one place.
- 🤝 **Consistent use:** all notification types share the same `Notify` contract.
- 🛠️ **Simpler client code:** callers receive a ready-to-use notification without knowing its construction details.
- ➕ **A focused extension point:** adding another notification type can be handled centrally, although this switch-based factory must itself be updated for every new type.

## 🧭 Where to Implement It

Use a factory at the boundary where an application decides which concrete implementation to create. Keep clients typed against an interface or base class, and let the factory return that abstraction. This is useful when there are multiple implementations, selection logic is repeated, or construction needs configuration.

For a small, stable set of options, a Simple Factory like this one is straightforward. If the set of implementations changes often or must be extended by separate modules, consider a registry, dependency injection, or the GoF Factory Method/Abstract Factory patterns instead of growing a long conditional switch.

## 🛒 Real-Life Example

An online store needs to send an order confirmation. A customer may prefer email or SMS. The order service requests a notification for the chosen channel and calls `Notify` with the confirmation. The service does not need separate email and SMS sending logic; the chosen notification implementation handles the channel-specific behavior. In this tutorial, the channel is selected by the factory argument and delivery is represented by console output.

## ⚠️ Limitation in This Example

The factory takes a free-form string, so callers must use the expected spelling and casing. An enum or another typed selection can make invalid choices harder to express. Also, `OrderService` currently chooses email directly; passing the selection into the service or supplying the factory externally would make the choice configurable and easier to test.
