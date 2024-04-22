namespace AspNetCoreIocExample.Dependencies;

public class SingletonDependency : Base<SingletonDependency>, IDisposable
{
    public SingletonDependency(ILogger<SingletonDependency> logger) : base(logger)
    {
        Logger.LogInformation("SingletonDependency ({Id}) is created", Id);
    }

    public override void Execute()
    {
        Logger.LogInformation("SingletonDependency ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("SingletonDependency ({Id}) is disposed", Id);
    }
}
