# Singleton Design Pattern

## 📖 What Is the Singleton Design Pattern?

The **Singleton Design Pattern** is a creational design pattern that ensures a class has only one instance and provides a global point of access to that instance.

In simple words, instead of creating multiple objects of a class, the Singleton pattern allows the application to reuse a single shared instance.

## 🤔 Why Do We Need the Singleton Pattern?

Consider a class responsible for managing application configuration. If every part of the application creates its own configuration manager, it may lead to unnecessary object creation and inconsistent state.

The Singleton pattern can help when a single shared instance is genuinely required.

Without Singleton:

```csharp
var config1 = new AppConfig();
var config2 = new AppConfig();

// Two different objects
```

With Singleton:

```csharp
var config1 = AppConfig.Instance;
var config2 = AppConfig.Instance;

// Both references point to the same object
```

## ✨ Benefits of the Singleton Pattern

- **Single Instance:** Ensures that the class exposes only one shared instance.
- **Controlled Access:** Controls how the instance is created and accessed.
- **Resource Efficiency:** Can avoid repeatedly creating expensive objects.
- **Shared State:** Allows different parts of an application to access the same instance and its state.
- **Centralized Management:** Useful when one object coordinates a shared application-wide responsibility.

## 📍 Where Should We Implement Singleton?

Singleton can be useful when an application genuinely requires one shared instance, such as:

- **Application Configuration:** Accessing immutable or centrally managed application settings.
- **Logging:** Sharing a logging component, although many logging frameworks manage this for you.
- **Caching:** Sharing a cache manager within a defined application scope.
- **Device Access:** Coordinating access to a resource that must have a single owner.
- **Shared Resource Coordination:** Managing a resource whose lifecycle and access need centralized control.

**Important:** A class does not need to be a Singleton simply because it is used frequently. In modern applications, dependency injection with an appropriate lifetime is often a better choice.

## 🌍 Real-Life Example

Imagine a company has a single official company-wide announcement board.

Every employee can read announcements from the same board, but the company does not create a separate official board for every employee.

Similarly, a Singleton provides a single shared instance that different parts of an application can access.

This analogy represents shared access. In software, the Singleton implementation must also control instance creation and access.

## 💻 C# Implementation

Here is a thread-safe Singleton implementation using `Lazy<T>`:

```csharp
public sealed class AppConfig
{
    private static readonly Lazy<AppConfig> _instance =
        new Lazy<AppConfig>(() => new AppConfig());

    public static AppConfig Instance => _instance.Value;

    private AppConfig()
    {
    }

    public string ApplicationName { get; set; } = "MyApp";
}
```

### Usage

```csharp
var config1 = AppConfig.Instance;
var config2 = AppConfig.Instance;

Console.WriteLine(
    ReferenceEquals(config1, config2)); // True
```

### How It Works

1. `sealed` prevents other classes from inheriting from `AppConfig`.
2. The private constructor prevents external code from creating instances directly.
3. `Lazy<AppConfig>` creates the instance when it is first accessed.
4. `Instance` provides a shared access point.
5. `Lazy<T>` with its default initialization mode provides thread-safe initialization.

_Note:_ This example demonstrates the Singleton pattern. In production applications, configuration values are often better handled using the .NET configuration system and dependency injection.

## ⚠️ Limitations and Considerations

- Can introduce global state and hidden dependencies.
- Can make unit testing and mocking more difficult.
- Mutable shared state can cause concurrency issues.
- Can make it harder to manage object lifetimes.
- May introduce unnecessary coupling between components.

Use Singleton only when a single shared instance is an actual requirement, rather than applying it everywhere.

## 🧠 Key Takeaway

The Singleton Design Pattern ensures that a class has one shared instance and provides a common access point to it.

**Remember:** Good design is not about using more design patterns. It is about choosing the right pattern to solve the right problem.
