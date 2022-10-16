namespace JFA.DependencyInjection;

public class ServiceInfo
{
    public Type Type { get; set; }

    public List<Type> BaseTypes { get; set; }

    public ELifetime Lifetime { get; set; }
}