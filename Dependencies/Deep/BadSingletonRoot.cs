namespace AspNetCoreIocExample.Dependencies.Deep;

public class BadSingletonRoot : Base<BadSingletonRoot>, IDisposable
{
    private readonly ScopedDependency _scopedDependency;
    private readonly TransientDependency _transientDependency;

    public BadSingletonRoot(
        ILogger<BadSingletonRoot> logger,
        ScopedDependency scopedDependency,
        TransientDependency transientDependency) : base(logger)
    {
        _scopedDependency = scopedDependency;
        _transientDependency = transientDependency;

        Logger.LogInformation("BadSingletonRoot ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _scopedDependency.Execute();
        _transientDependency.Execute();

        Logger.LogInformation("BadSingletonRoot ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("BadSingletonRoot ({Id}) is disposed", Id);
    }
}
