namespace AspNetCoreIocExample.Dependencies.Deep;

public class ScopedRoot : Base<ScopedRoot>, IDisposable
{

    private readonly SingletonChild _singletonChild;
    private readonly SingletonDependency _singletonDependency;
    private readonly ScopedChild _scopedChild;
    private readonly ScopedDependency _scopedDependency;

    public ScopedRoot(
        ILogger<ScopedRoot> logger,
        SingletonChild singletonChild,
        SingletonDependency singletonDependency,
        ScopedChild scopedChild,
        ScopedDependency scopedDependency) : base(logger)
    {
        _singletonChild = singletonChild;
        _singletonDependency = singletonDependency;
        _scopedChild = scopedChild;
        _scopedDependency = scopedDependency;

        Logger.LogInformation("ScopedRoot ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _singletonChild.Execute();
        _singletonDependency.Execute();
        _scopedChild.Execute();
        _scopedDependency.Execute();

        Logger.LogInformation("ScopedRoot ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("ScopedRoot ({Id}) is disposed", Id);
    }
}
