# Dependency Injection Example

This project demonstrates the Dependency Injection (DI) pattern in C# using the Microsoft.Extensions.DependencyInjection library. It showcases how to set up a simple console application that utilizes DI to manage dependencies between classes.

## Project Structure

The project consists of the following files:

- **src/Program.cs**: The entry point of the application. It sets up the dependency injection container, registers services, and retrieves an instance of `MyClass` to demonstrate dependency injection.
  
- **src/IMyService.cs**: Defines the `IMyService` interface, which declares the method `DoSomething` that must be implemented by any class providing this service.
  
- **src/MyService.cs**: Implements the `IMyService` interface in the `MyService` class. It provides the actual implementation of the `DoSomething` method, which outputs a message to the console.
  
- **src/MyClass.cs**: Defines the `MyClass` class, which has a constructor that takes an `IMyService` instance as a parameter. It contains a method `DoSomething` that calls the `DoSomething` method of the injected `IMyService` instance.

- **DependencyInjectionExample.csproj**: The project file for the C# project. It contains metadata about the project, including dependencies and build settings.

## Getting Started

To run this project, follow these steps:

1. **Clone the repository** or download the project files to your local machine.

2. **Open a terminal** and navigate to the project directory.

3. **Restore the dependencies** by running the following command:
   ```
   dotnet restore
   ```

4. **Run the application** using the following command:
   ```
   dotnet run --project src/Program.cs
   ```

5. You should see the output:
   ```
   MyService is doing something.
   ```

This output indicates that the dependency injection was successful and that the `MyService` class was called through the `MyClass` instance.

## Conclusion

This example illustrates the basics of Dependency Injection in C#. By using DI, you can create more modular, testable, and maintainable code. For more advanced scenarios, consider exploring additional features of the Microsoft.Extensions.DependencyInjection library and other DI containers available in the .NET ecosystem.