// Copyright (C) Siemens AG 2022-2024. All rights reserved. Confidential.

Console.WriteLine("Hello, World!\n");

// tag::class-injection-program[]
Console.WriteLine("Class Injection\n");

var classInjectionLogicFoo = new ClassInjectionFooLogic(new InternalDependencyFoo());
var classInjectionLogicBar = new ClassInjectionBarLogic(new InternalDependencyBar());
var classInjectionLogicFooBar = new ClassInjectionFooBarLogic(new InternalDependencyFoo(), new InternalDependencyBar());

classInjectionLogicFoo.Do();
classInjectionLogicBar.Do();
classInjectionLogicFooBar.Do();

// end::class-injection-program[]

// tag::interface-injection-program[]
Console.WriteLine("\nInterface Injection\n");

var repo = Repository.Default;
var fooBarDependency = new ChainDependency(repo.FooInterface, repo.BarInterface);

var interfaceInjectionLogicFoo = new InterfaceInjectionLogic(repo.ExternalInterface, repo.FooInterface);
var interfaceInjectionLogicBar = new InterfaceInjectionLogic(repo.ExternalInterface, repo.BarInterface);
var interfaceInjectionLogicFooBar = new InterfaceInjectionLogic(repo.ExternalInterface, fooBarDependency);

interfaceInjectionLogicFoo.Do();
interfaceInjectionLogicBar.Do();
interfaceInjectionLogicFooBar.Do();
// end::interface-injection-program[]

// tag::pure-action-injection-program[]
Console.WriteLine("\nPure Action Injection\n");

var pureActionInjectionLogicFoo = new PureActionInjectionLogic(
    repo.ExternalInterface.DoSomething,
    repo.ExternalInterface.DoSomethingMore,
    repo.FooInterface.DoSomethingInternalStuff,
    repo.FooInterface.DoSomethingMoreInternalStuff
);

var pureActionInjectionLogicBar = new PureActionInjectionLogic(
    repo.ExternalInterface.DoSomething,
    repo.ExternalInterface.DoSomethingMore,
    repo.BarInterface.DoSomethingInternalStuff,
    repo.BarInterface.DoSomethingMoreInternalStuff
);

var pureActionInjectionLogicFooBar = new PureActionInjectionLogic(
    repo.ExternalInterface.DoSomething,
    repo.ExternalInterface.DoSomethingMore,
    repo.FooInterface.DoSomethingInternalStuff,
    () =>
    {
        Console.WriteLine("injected Code");
        repo.BarInterface.DoSomethingMoreInternalStuff();
    }
);

pureActionInjectionLogicFoo.Do();
pureActionInjectionLogicBar.Do();
pureActionInjectionLogicFooBar.Do();
// end::pure-action-injection-program[]

// tag::action-injection-program[]
Console.WriteLine("\nAction Injection with external interface\n");

var actionInjectionLogicFoo = new ActionInjectionLogic(
    repo.ExternalInterface,
    repo.FooInterface.DoSomethingInternalStuff,
    repo.FooInterface.DoSomethingMoreInternalStuff
);

var actionInjectionLogicBar = new ActionInjectionLogic(
    repo.ExternalInterface,
    repo.BarInterface.DoSomethingInternalStuff,
    repo.BarInterface.DoSomethingMoreInternalStuff
);

var actionInjectionLogicFooBar = new ActionInjectionLogic(
    repo.ExternalInterface,
    repo.FooInterface.DoSomethingInternalStuff,
    repo.BarInterface.DoSomethingMoreInternalStuff
);


actionInjectionLogicFoo.Do();
actionInjectionLogicBar.Do();
actionInjectionLogicFooBar.Do();
// end::action-injection-program[]


// tag::operation-injection-program[]
Console.WriteLine("\nOperations Injection\n");

var fooOperations = new OperationsInjectionLogic.Operations()
{
    DoSomethingInternalStuff = repo.FooInterface.DoSomethingInternalStuff,
    DoSomethingMoreInternalStuff = repo.FooInterface.DoSomethingMoreInternalStuff
};

var barOperations = new OperationsInjectionLogic.Operations()
{
    DoSomethingInternalStuff = repo.BarInterface.DoSomethingInternalStuff,
    DoSomethingMoreInternalStuff = repo.BarInterface.DoSomethingMoreInternalStuff
};

var fooBarOperations = fooOperations with
{
    DoSomethingMoreInternalStuff = barOperations.DoSomethingMoreInternalStuff
};

var operationInjectionLogicFoo = new OperationsInjectionLogic(
    repo.ExternalInterface,
    fooOperations
);

var operationInjectionLogicBar = new OperationsInjectionLogic(
    repo.ExternalInterface,
    barOperations
);

var operationInjectionLogicFooBar = new OperationsInjectionLogic(
    repo.ExternalInterface,
    fooBarOperations
);


operationInjectionLogicFoo.Do();
operationInjectionLogicBar.Do();
operationInjectionLogicFooBar.Do();

// end::operation-injection-program[]

// tag::injection-location-program[]
Console.WriteLine("\nInjection location\n");

var logger = repo.Logger;
var consoleLogger = repo.ConsoleLogger;

var file = repo.CreateFile("foo.txt");
var otherFile = repo.CreateFile("bar.txt");

var constructorLogic1 = new ConstructorOnlyLogic(logger, file);
constructorLogic1.Do();

var constructorLogic2 = new ConstructorOnlyLogic(logger, otherFile);
constructorLogic2.Do();

var constructorLogic3 = new ConstructorOnlyLogic(consoleLogger, file);
constructorLogic3.Do();

StaticMethodLogic.Do(logger, file);
StaticMethodLogic.Do(logger, otherFile);
StaticMethodLogic.Do(consoleLogger, file);

var constructorAndMethodLogic = new ConstructorAndMethodLogic(logger);
constructorAndMethodLogic.Do(file);
constructorAndMethodLogic.Do(otherFile);

var constructorAndMethodLogic2 = new ConstructorAndMethodLogic(consoleLogger);
constructorAndMethodLogic2.Do(file);

var constructorAndMethodAndStaticLogic = new ConstructorAndMethodAndStaticLogic(logger);
constructorAndMethodAndStaticLogic.Do(file);
constructorAndMethodAndStaticLogic.Do(otherFile);
ConstructorAndMethodAndStaticLogic.Do(consoleLogger, file);
// end::injection-location-program[]


// tag::injection-common-contract[]

public interface IExternalInterface
{
    void DoSomething();


    void DoSomethingMore();
}

// end::injection-common-contract[]

// tag::interface-injection-contract[]
internal interface IInternalInterface
{
    void DoSomethingInternalStuff();

    void DoSomethingMoreInternalStuff();
}
// end::interface-injection-contract[]

internal class Repository
{
    private sealed class ExternalInterfaceImpl : IExternalInterface
    {
        void IExternalInterface.DoSomething()
        {
            Console.WriteLine("Hello External, DoSomething()");
        }

        void IExternalInterface.DoSomethingMore()
        {
            Console.WriteLine("Hello External, DoSomethingMore()");
        }
    }

    private sealed class File : IFile
    {
        public File(string path)
        {
            Path = path ?? string.Empty;
        }

        public string Path { get; }
    }

    private sealed class TraceLogger : ILog
    {
        public void Trace(string msg)
        {
            System.Diagnostics.Trace.WriteLine(msg);
        }
    }

    private sealed class MyConsoleLogger : ILog
    {
        public void Trace(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }

    public IInternalInterface BarInterface { get; init; } = new InternalDependencyBar();

    public static Repository Default { get; } = new Repository();

    public IExternalInterface ExternalInterface { get; init; } = new ExternalInterfaceImpl();

    public IInternalInterface FooInterface { get; init; } = new InternalDependencyFoo();

    public IFile CreateFile(string path) => new File(path);

    public ILog Logger { get; init; } = new TraceLogger();

    public ILog ConsoleLogger { get; init; } = new TraceLogger();
}

// tag::injection-common-contract[]
internal sealed class InternalDependencyFoo : IInternalInterface
{
    public void DoSomethingInternalStuff()
    {
        Console.WriteLine("Hello Foo, DoSomethingInternalStuff");
    }

    public void DoSomethingMoreInternalStuff()
    {
        Console.WriteLine("Hello Foo, DoSomethingMoreInternalStuff()");
    }
}

internal sealed class InternalDependencyBar : IInternalInterface
{
    public void DoSomethingInternalStuff()
    {
        Console.WriteLine("Hello Bar, DoSomethingInternalStuff");
    }

    public void DoSomethingMoreInternalStuff()
    {
        Console.WriteLine("Hello Bar, DoSomethingMoreInternalStuff()");
    }
}
// end::injection-common-contract[]

// tag::class-injection-logic[]
internal sealed class ClassInjectionFooLogic
{
    private readonly InternalDependencyFoo m_Internal;

    public ClassInjectionFooLogic(InternalDependencyFoo @internal)
    {
        m_Internal = @internal;
    }

    public void Do()
    {
        m_Internal.DoSomethingInternalStuff();
        m_Internal.DoSomethingMoreInternalStuff();
    }
}

internal sealed class ClassInjectionFooBarLogic
{
    private readonly InternalDependencyFoo m_InternalFoo;
    private readonly InternalDependencyBar m_InternalBar;

    public ClassInjectionFooBarLogic(
        InternalDependencyFoo @internalFoo, 
        InternalDependencyBar @internalBar)
    {
        m_InternalFoo = @internalFoo;
        m_InternalBar = @internalBar;
    }

    public void Do()
    {
        m_InternalFoo.DoSomethingInternalStuff();
        m_InternalBar.DoSomethingMoreInternalStuff();
    }
}

internal sealed class ClassInjectionBarLogic
{
    private readonly InternalDependencyBar m_Internal;

    public ClassInjectionBarLogic(InternalDependencyBar @internal)
    {
        m_Internal = @internal;
    }

    public void Do()
    {
        m_Internal.DoSomethingInternalStuff();
        m_Internal.DoSomethingMoreInternalStuff();
    }
}
// end::class-injection-logic[]

// tag::interface-injection-logic[]
internal sealed class ChainDependency : IInternalInterface
{
    private readonly IInternalInterface m_SomethingInterface;

    private readonly IInternalInterface m_SomethingMoreInterface;


    public ChainDependency(IInternalInterface somethingInterface, IInternalInterface somethingMoreInterface)
    {
        m_SomethingInterface = somethingInterface;
        m_SomethingMoreInterface = somethingMoreInterface;
    }

    public void DoSomethingInternalStuff()
    {
        m_SomethingInterface.DoSomethingInternalStuff();
    }

    public void DoSomethingMoreInternalStuff()
    {
        m_SomethingMoreInterface.DoSomethingMoreInternalStuff();
    }
}

internal sealed class InterfaceInjectionLogic
{
    private readonly IExternalInterface m_External;
    private readonly IInternalInterface m_Internal;

    public InterfaceInjectionLogic(IExternalInterface external, IInternalInterface @internal)
    {
        m_External = external;
        m_Internal = @internal;
    }

    public void Do()
    {
        m_External.DoSomething();
        m_External.DoSomethingMore();
        m_Internal.DoSomethingInternalStuff();
        m_Internal.DoSomethingMoreInternalStuff();
    }
}

// end::interface-injection-logic[]

// tag::pure-action-injection-logic[]
internal sealed class PureActionInjectionLogic
{
    private readonly Action m_DoSomething;
    private readonly Action m_DoSomethingInternalStuff;
    private readonly Action m_DoSomethingMore;
    private readonly Action m_DoSomethingMoreInternalStuff;


    public PureActionInjectionLogic(
        Action doSomething,
        Action doSomethingMore,
        Action doSomethingInternalStuff,
        Action doSomethingMoreInternalStuff)
    {
        m_DoSomethingInternalStuff = doSomethingInternalStuff;
        m_DoSomethingMoreInternalStuff = doSomethingMoreInternalStuff;
        m_DoSomething = doSomething;
        m_DoSomethingMore = doSomethingMore;
    }

    public void Do()
    {
        m_DoSomething();
        m_DoSomethingMore();
        m_DoSomethingInternalStuff();
        m_DoSomethingMoreInternalStuff();
    }
}
// end::pure-action-injection-logic[]

// tag::action-injection-logic[]
internal sealed class ActionInjectionLogic
{
    private readonly Action m_DoSomethingInternalStuff;
    private readonly Action m_DoSomethingMoreInternalStuff;
    private readonly IExternalInterface m_External;

    public ActionInjectionLogic(
        IExternalInterface external,
        Action doSomethingInternalStuff,
        Action doSomethingMoreInternalStuff)
    {
        m_External = external;
        m_DoSomethingInternalStuff = doSomethingInternalStuff;
        m_DoSomethingMoreInternalStuff = doSomethingMoreInternalStuff;
    }

    public void Do()
    {
        m_External.DoSomething();
        m_External.DoSomethingMore();
        m_DoSomethingInternalStuff();
        m_DoSomethingMoreInternalStuff();
    }
}
// end::action-injection-logic[]

// tag::operation-injection-logic[]

internal sealed class OperationsInjectionLogic
{
    private readonly IExternalInterface m_External;

    private readonly Operations m_Operations;

    public OperationsInjectionLogic(
        IExternalInterface external,
        Operations operations)
    {
        m_External = external;
        m_Operations = operations;
    }

    public void Do()
    {
        m_External.DoSomething();
        m_External.DoSomethingMore();
        m_Operations.DoSomethingInternalStuff();
        m_Operations.DoSomethingMoreInternalStuff();
    }

    public sealed record Operations
    {
        public Action DoSomethingInternalStuff { get; init; } = () => { };
        public Action DoSomethingMoreInternalStuff { get; init; } = () => { };
    }
}

// end::operation-injection-logic[]


// tag::injection-location-contract[]
public interface ILog
{
    void Trace(string msg);
}

public interface IFile
{
    string Path { get; }
}
// end::injection-location-contract[]

// tag::injection-location-logic[]
internal sealed class ConstructorOnlyLogic
{
    private readonly ILog m_Log;

    private readonly IFile m_File;

    public ConstructorOnlyLogic(ILog log, IFile file)
    {
        m_Log = log;
        m_File = file;
    }

    public void Do()
    {
        m_Log.Trace("create file");
        File.Create(m_File.Path);
    }
}

internal static class StaticMethodLogic
{
    public static void Do(ILog log, IFile file)
    {
        log.Trace("create file");
        File.Create(file.Path);
    }
}

internal sealed class ConstructorAndMethodLogic
{
    private readonly ILog m_Log;
    
    public ConstructorAndMethodLogic(ILog log)
    {
        m_Log = log;
    }

    public void Do(IFile file)
    {
        m_Log.Trace("create file");
        File.Create(file.Path);
    }
}

internal sealed class ConstructorAndMethodAndStaticLogic
{
    private readonly ILog m_Log;

    public ConstructorAndMethodAndStaticLogic(ILog log)
    {
        m_Log = log;
    }

    public void Do(IFile file)
    {
        Do(m_Log, file);
    }

    public static void Do(ILog log, IFile file)
    {
        log.Trace("create file");
        File.Create(file.Path);
    }
}
// end::injection-location-logic[]
