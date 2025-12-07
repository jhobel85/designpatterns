# Übersicht

Design-Patterns sind bewährte Lösungsschablonen für wiederkehrende Entwurfsprobleme in der Softwareentwicklung. Sie bieten erprobte Ansätze, um die Struktur und Interaktion von Klassen und Objekten zu gestalten. Dabei geht es nicht um konkrete Implementierungen, sondern um allgemeine Konzepte.

Die Vorteile von Design-Patterns lassen sich so illustrieren:

```mermaid
graph LR
A[Design-Patterns] --> B[Wiederverwendbarkeit]
A --> C[Wartbarkeit]
A --> D[Flexibilität]
A --> E[Kommunikation]
A --> F[Best Practices]
```

Es gibt drei Hauptkategorien von Patterns, die sich anhand ihrer Zwecke unterscheiden:

```mermaid
graph TD
A[Design-Patterns] --> B[Erzeugungsmuster]
A --> C[Strukturmuster]
A --> D[Verhaltensmuster]
```

1. Erzeugungsmuster (Creational Patterns): 
   Sie befassen sich mit der Objekterzeugung und entkoppeln die Erstellung von Objekten von ihrer Verwendung. 

```mermaid
classDiagram
class Client
class Creator {
  +factoryMethod()
}
class ConcreteCreator {
  +factoryMethod()
}
class Product {
  +operation()
}
class ConcreteProduct {
  +operation()
}
Client --> Creator : creates
Creator <|-- ConcreteCreator
ConcreteCreator ..> ConcreteProduct : creates
Product <|-- ConcreteProduct
```

2. Strukturmuster (Structural Patterns):
   Sie befassen sich mit der Zusammensetzung von Klassen und Objekten zu größeren Strukturen. Dabei geht es oft darum, Schnittstellen zu vereinfachen oder zusätzliche Funktionalität hinzuzufügen.

```mermaid
classDiagram
class Client
class Target {
  +request()
}
class Adaptee {
  +specificRequest()
}
class Adapter {
  +request()
}
Client --> Target
Target <|-- Adapter
Adapter o-- Adaptee
```

3. Verhaltensmuster (Behavioral Patterns):
   Sie befassen sich mit der Interaktion und Aufgabenverteilung zwischen Objekten. Dabei geht es um flexibles Objektverhalten und die Kapselung von Algorithmen.

```mermaid
classDiagram
class Subject {
  +attach(observer)
  +detach(observer)
  +notify()
}
class ConcreteSubject {
  -subjectState
  +getState()
  +setState()
}
class Observer {
  +update()
}
class ConcreteObserver {
  -observerState
  +update()
}
Subject o-- Observer
ConcreteSubject --|> Subject
ConcreteObserver ..|> Observer
```

Die Diagramme zeigen die grundlegenden Strukturen und Beziehungen einiger ausgewählter Patterns. In den nächsten Abschnitten werden wir sie im Detail besprechen und ihre Umsetzung in C# anschauen.

## Nächste Schritte

[Singleton Pattern](patterns/Singleton%20Pattern.md)