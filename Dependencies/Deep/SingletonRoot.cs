namespace AspNetCoreIocExample.Dependencies.Deep;

public class SingletonRoot : Base<SingletonRoot>, IDisposable
{
    private readonly SingletonChild _singletonChild;
    private readonly SingletonDependency _singletonDependency;

    public SingletonRoot(
        ILogger<SingletonRoot> logger,
        SingletonChild singletonChild,
        SingletonDependency singletonDependency) : base(logger)
    {
        _singletonChild = singletonChild;
        _singletonDependency = singletonDependency;

        Logger.LogInformation("SingletonRoot ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _singletonChild.Execute();
        _singletonDependency.Execute();

        Logger.LogInformation("SingletonRoot ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("SingletonRoot ({Id}) is disposed", Id);
    }
}
