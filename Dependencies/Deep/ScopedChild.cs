namespace AspNetCoreIocExample.Dependencies.Deep;

public class ScopedChild : Base<ScopedChild>, IDisposable
{
    public ScopedChild(ILogger<ScopedChild> logger) : base(logger)
    {
        Logger.LogInformation("ScopedChild ({Id}) is created", Id);
    }

    public override void Execute()
    {
        Logger.LogInformation("ScopedChild ({Id}) is executed", Id);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        Logger.LogInformation("ScopedChild ({Id}) is disposed", Id);
    }
}
