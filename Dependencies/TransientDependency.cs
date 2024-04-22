namespace AspNetCoreIocExample.Dependencies;

public class TransientDependency : Base<TransientDependency>, IDisposable
{
    public TransientDependency(ILogger<TransientDependency> logger) : base(logger)
    {
        Logger.LogInformation("TransientDependency ({Id}) is created", Id);
    }

    public override void Execute()
    {
        Logger.LogInformation("TransientDependency ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("TransientDependency ({Id}) is disposed", Id);
    }
}
