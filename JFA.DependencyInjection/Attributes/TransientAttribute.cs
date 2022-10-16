namespace JFA.DependencyInjection;

public class TransientAttribute : ServiceAttribute
{
    public TransientAttribute() => Lifetime = ELifetime.Transient;
}