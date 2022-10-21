using JFA.DependencyContainer;

namespace JFA.DependencyInjection;

public static class DependencyResolverExtensions
{
    public static void AddServicesFromAttribute(this DependencyResolver resolver)
    {
        foreach (var service in AttributeServices.GetServices())
        {
            switch (service.Lifetime)
            {
                case ELifetime.Transient:
                    service.BaseTypes.ForEach(baseType => resolver.Services.AddTransient(baseType, service.Type)); break;
                case ELifetime.Scoped:
                    service.BaseTypes.ForEach(baseType => resolver.Services.AddScoped(baseType, service.Type)); break;
                case ELifetime.Singleton:
                    service.BaseTypes.ForEach(baseType => resolver.Services.AddSingleton(baseType, service.Type)); break;
            }
        }
    }
}