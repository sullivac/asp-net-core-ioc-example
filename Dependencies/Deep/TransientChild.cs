namespace AspNetCoreIocExample.Dependencies.Deep;

public class TransientChild : Base<TransientChild>, IDisposable
{
    private readonly ScopedChild _scopedChild;
    private readonly TransientDependency _transientDependency;

    public TransientChild(
        ILogger<TransientChild> logger,
        ScopedChild scopedChild,
        TransientDependency transientDependency) : base(logger)
    {
        _scopedChild = scopedChild;
        _transientDependency = transientDependency;

        Logger.LogInformation("TransientChild ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _scopedChild.Execute();
        _transientDependency.Execute();

        Logger.LogInformation("TransientChild ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("TransientChild ({Id}) is disposed", Id);
    }
}
