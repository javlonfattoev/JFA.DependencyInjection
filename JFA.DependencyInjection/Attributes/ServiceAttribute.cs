namespace JFA.DependencyInjection;

public class ServiceAttribute : Attribute
{
    public ELifetime Lifetime { get; set; }
}