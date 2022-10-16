namespace JFA.DependencyInjection;

public class ScopedAttribute : ServiceAttribute
{
    public ScopedAttribute() => Lifetime = ELifetime.Scoped;
}