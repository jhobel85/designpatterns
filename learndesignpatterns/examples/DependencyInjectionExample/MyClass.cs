using DependencyInjectionExample;

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