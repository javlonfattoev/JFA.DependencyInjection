namespace JFA.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ServiceAttribute : Attribute
{
    public ELifetime Lifetime { get; set; }
}