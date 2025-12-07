# Dependency Injection

Dependency Injection (DI) ist ein Entwurfsmuster und ein Prinzip in der Softwareentwicklung, bei dem die Abhängigkeiten einer Klasse von außen bereitgestellt werden, anstatt sie innerhalb der Klasse zu erstellen. Es ist eine Methode zur Entkopplung von Objekten und zur Förderung der losen Kopplung und Wiederverwendbarkeit von Code.

Bei der Dependency Injection werden die Abhängigkeiten einer Klasse, d.h. die Objekte, die sie benötigt, um ihre Aufgaben zu erfüllen, über Konstruktorparameter, Setter-Methoden oder Schnittstellen übergeben. Dadurch wird die Verantwortung für die Erstellung und Verwaltung dieser Abhängigkeiten an eine externe Komponente, oft einen DI-Container oder den aufrufenden Code, übertragen.

Es gibt drei Hauptarten von Dependency Injection:

1. Konstruktor-Injection:
   Die Abhängigkeiten werden über den Konstruktor der Klasse übergeben. Dies ist die am häufigsten verwendete Art der Injection.

```csharp
public class MyClass
{
    private readonly IDependency dependency;

    public MyClass(IDependency dependency)
    {
        this.dependency = dependency;
    }
}
```

2. Setter-Injection (auch Property-Injection genannt):
   Die Abhängigkeiten werden über Setter-Methoden oder Properties der Klasse übergeben.

```csharp
public class MyClass
{
    private IDependency dependency;

    public IDependency Dependency
    {
        set { dependency = value; }
    }
}
```

3. Interface-Injection:
   Die Klasse implementiert eine Schnittstelle, die eine Methode zum Injizieren der Abhängigkeiten definiert.

```csharp
public interface IInjectable
{
    void InjectDependency(IDependency dependency);
}

public class MyClass : IInjectable
{
    private IDependency dependency;

    public void InjectDependency(IDependency dependency)
    {
        this.dependency = dependency;
    }
}
```

Vorteile von Dependency Injection:

1. Lose Kopplung:
   Klassen sind nicht eng mit ihren Abhängigkeiten verbunden, was die Flexibilität und Wiederverwendbarkeit erhöht.

2. Testbarkeit:
   Abhängigkeiten können durch Mock-Objekte oder Stub-Implementierungen ersetzt werden, um Komponenten isoliert zu testen.

3. Erweiterbarkeit:
   Neue Funktionen können leicht hinzugefügt werden, indem neue Implementierungen der Abhängigkeiten erstellt werden, ohne bestehenden Code zu ändern.

4. Vereinfachte Wartung:
   Änderungen an Abhängigkeiten wirken sich nicht auf die Klassen aus, die sie verwenden, solange die Schnittstellen gleich bleiben.

Dependency Injection wird oft in Verbindung mit einem DI-Container verwendet, der die Erstellung und Verwaltung der Abhängigkeiten übernimmt. Beliebte DI-Container in .NET sind beispielsweise Autofac, Ninject und der eingebaute Microsoft.Extensions.DependencyInjection.

Durch die Anwendung von Dependency Injection können Entwickler modulareren, flexibleren und besser testbaren Code schreiben. Es fördert die Einhaltung des Dependency Inversion Principle (DIP) und ist ein Schlüsselkonzept in der modernen Softwareentwicklung.

## Beispiel für Dependency Injection in C# unter Verwendung von Microsofts DependencyInjection Bibliothek

Hier ist ein Beispiel, das zeigt, wie Du Dependency Injection mit Microsoft.Extensions.DependencyInjection in einer Konsolenanwendung verwenden kannst:

1. Erstelle eine neue Konsolenanwendung in Visual Studio oder über die Befehlszeile mit `dotnet new console`.

2. Füge das NuGet-Paket `Microsoft.Extensions.DependencyInjection` hinzu. In Visual Studio kannst Du dies über den NuGet-Paket-Manager tun, oder Du verwendest den Befehl `dotnet add package Microsoft.Extensions.DependencyInjection` in der Befehlszeile.

3. Definiere eine Schnittstelle und eine Implementierung für einen Dienst, den wir injizieren möchten:

```csharp
public interface IMyService
{
    void DoSomething();
}

public class MyService : IMyService
{
    public void DoSomething()
    {
        Console.WriteLine("MyService is doing something.");
    }
}
```

4. Definiere eine Klasse, die den injizierten Dienst verwendet:

```csharp
public class MyClass
{
    private readonly IMyService myService;

    public MyClass(IMyService myService)
    {
        this.myService = myService;
    }

    public void DoSomething()
    {
        myService.DoSomething();
    }
}
```

5. Konfiguriere den DI-Container und verwende ihn in der `Main`-Methode:

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Erstelle einen neuen DI-Container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IMyService, MyService>()
            .AddTransient<MyClass>()
            .BuildServiceProvider();

        // Fordere eine Instanz von MyClass an
        var myClass = serviceProvider.GetService<MyClass>();
        myClass.DoSomething();
    }
}
```

Hier ist der vollständige Code:

```csharp
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExample
{
    public interface IMyService
    {
        void DoSomething();
    }

    public class MyService : IMyService
    {
        public void DoSomething()
        {
            Console.WriteLine("MyService is doing something.");
        }
    }

    public class MyClass
    {
        private readonly IMyService myService;

        public MyClass(IMyService myService)
        {
            this.myService = myService;
        }

        public void DoSomething()
        {
            myService.DoSomething();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMyService, MyService>()
                .AddTransient<MyClass>()
                .BuildServiceProvider();

            var myClass = serviceProvider.GetService<MyClass>();
            myClass.DoSomething();
        }
    }
}
```

In diesem Beispiel wird `MyService` als Singleton registriert, d.h. es wird nur eine Instanz erstellt und wiederverwendet. `MyClass` wird als Transient registriert, d.h. jedes Mal, wenn es angefordert wird, wird eine neue Instanz erstellt.

Wenn Du das Programm ausführst, sollte es "MyService is doing something." ausgeben, was zeigt, dass die Abhängigkeit erfolgreich injiziert wurde.

Das ist ein einfaches Beispiel, aber es zeigt die Grundlagen der Verwendung von Microsoft.Extensions.DependencyInjection. In größeren Anwendungen würdest Du normalerweise die Registrierung der Dienste in einer separaten Klasse oder Methode vornehmen, um die `Main`-Methode übersichtlich zu halten.

## Quellen

Es gibt viele frei zugängliche Quellen im Internet, die das Thema Dependency Injection ausführlich behandeln. Hier sind einige davon:

1. Microsoft Documentation - Dependency Injection in .NET:
   https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection
   Die offizielle Dokumentation von Microsoft bietet eine umfassende Einführung in Dependency Injection und zeigt, wie man es in .NET Core-Anwendungen implementiert.

2. Martin Fowler's Blog - Inversion of Control Containers and the Dependency Injection pattern:
   https://martinfowler.com/articles/injection.html
   In diesem Artikel erklärt Martin Fowler, ein bekannter Softwareentwickler und Autor, die Grundlagen von Dependency Injection und Inversion of Control (IoC) Containern.

3. Tutorials Point - Dependency Injection Tutorial:
   https://www.tutorialspoint.com/dependency_injection/index.htm
   Dieses Tutorial bietet eine schrittweise Anleitung zu Dependency Injection mit Beispielen in Java, die aber auch auf andere Sprachen übertragbar sind.

4. Stackoverflow - Dependency Injection Dokumentation:
   https://stackoverflow.com/documentation/dependency-injection/topics
   Die Dokumentation auf Stackoverflow enthält eine Sammlung von Artikeln und Beispielen zu Dependency Injection, die von der Community erstellt und bewertet wurden.

5. Freecodecamp - A quick intro to Dependency Injection: what it is, and when to use it:
   https://www.freecodecamp.org/news/a-quick-intro-to-dependency-injection-what-it-is-and-when-to-use-it-7578c84fa88f/
   Dieser Artikel auf Freecodecamp gibt eine kurze Einführung in Dependency Injection und erklärt, wann und warum man es verwenden sollte.

6. Codecademy - What is Dependency Injection?:
   https://www.codecademy.com/articles/what-is-dependency-injection
   Dieser Artikel auf Codecademy erklärt Dependency Injection auf einfache und verständliche Weise und zeigt einige Codebeispiele.

7. Google Developers - Dependency Injection:
   https://developers.google.com/android/training/dependency-injection
   Dieser Artikel auf der Google Developers-Website erklärt Dependency Injection im Kontext der Android-App-Entwicklung, aber die Konzepte sind auch auf andere Plattformen anwendbar.

Diese Quellen sollten Dir einen guten Einstieg in das Thema Dependency Injection bieten. Sie enthalten sowohl theoretische Erklärungen als auch praktische Codebeispiele. Je nach Deinem Hintergrund und Deiner bevorzugten Lernmethode kannst Du die Quelle wählen, die am besten zu Dir passt.

Es gibt auch viele Bücher und Online-Kurse, die Dependency Injection behandeln, aber die oben genannten Quellen sind kostenlos und frei zugänglich.