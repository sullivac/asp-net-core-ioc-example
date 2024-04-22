namespace AspNetCoreIocExample.Dependencies;

public class ScopedDependency : Base<ScopedDependency>, IDisposable
{
    public ScopedDependency(ILogger<ScopedDependency> logger) : base(logger)
    {
        Logger.LogInformation("ScopedDependency ({Id}) is created", Id);
    }

    public override void Execute()
    {
        Logger.LogInformation("ScopedDependency ({Id}) is executed", Id);
    
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("ScopedDependency ({Id}) is disposed", Id);
    }
}
