namespace JFA.DependencyInjection;

public class ServiceInfo
{
    public Type Type { get; set; } = null!;

    public List<Type> BaseTypes { get; set; } = new List<Type>();

    public ELifetime Lifetime { get; set; }
}