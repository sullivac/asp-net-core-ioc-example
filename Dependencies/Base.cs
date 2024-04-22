namespace AspNetCoreIocExample.Dependencies;

public abstract class Base<T>(ILogger<T> _logger)
{
    private readonly Guid _id = Guid.NewGuid();

    protected Guid Id => _id;
    
    protected ILogger<T> Logger => _logger;

    public abstract void Execute();
}
