namespace JFA.DependencyInjection;

public class SingletonAttribute : ServiceAttribute
{
    public SingletonAttribute() => Lifetime = ELifetime.Singleton;
}