namespace AspNetCoreIocExample.Dependencies.Deep;

public class SingletonChild : Base<SingletonChild>, IDisposable
{
    private readonly SingletonDependency _singletonDependency;

    public SingletonChild(ILogger<SingletonChild> logger, SingletonDependency singletonDependency) : base(logger)
    {
        _singletonDependency = singletonDependency;

        Logger.LogInformation("SingletonChild ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _singletonDependency.Execute();

        Logger.LogInformation("SingletonChild ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("SingletonChild ({Id}) is disposed", Id);
    }
}
