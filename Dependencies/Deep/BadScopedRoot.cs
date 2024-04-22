namespace AspNetCoreIocExample.Dependencies.Deep;

public class BadScopedRoot : Base<BadScopedRoot>, IDisposable
{
    private readonly TransientDependency _transientDependency;

    public BadScopedRoot(
        ILogger<BadScopedRoot> logger,
        TransientDependency transientDependency) : base(logger)
    {
        _transientDependency = transientDependency;

        Logger.LogInformation("BadScopedDependency ({Id}) is created", Id);
    }

    public override void Execute()
    {
        _transientDependency.Execute();

        Logger.LogInformation("BadScopedDependency ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("BadScopedDependency ({Id}) is disposed", Id);
    }
}
