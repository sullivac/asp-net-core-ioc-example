namespace AspNetCoreIocExample.Dependencies.Deep;

public class TransientRoot : Base<TransientRoot>, IDisposable
{
    private readonly ScopedChild _scopedChild;
    private readonly ScopedDependency _scopedDependency;
    private readonly SingletonChild _singletonChild;
    private readonly SingletonDependency _singletonDependency;
    private readonly TransientChild _transientChild;
    private readonly TransientDependency _transientDependency;

    public TransientRoot(
        ILogger<TransientRoot> logger,
        SingletonChild singletonChild,
        SingletonDependency singletonDependency,
        ScopedChild scopedChild,
        ScopedDependency scopedDependency,
        TransientChild transientChild,
        TransientDependency transientDependency) : base(logger)
    {
        _singletonChild = singletonChild;
        _singletonDependency = singletonDependency;
        _scopedChild = scopedChild;
        _scopedDependency = scopedDependency;
        _transientChild = transientChild;
        _transientDependency = transientDependency;

        Logger.LogInformation("TransientRoot ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _singletonChild.Execute();
        _singletonDependency.Execute();
        _scopedChild.Execute();
        _scopedDependency.Execute();
        _transientChild.Execute();
        _transientDependency.Execute();

        Logger.LogInformation("TransientRoot ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("TransientRoot ({Id}) is disposed", Id);
    }
}
