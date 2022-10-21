using Microsoft.Extensions.DependencyInjection;

namespace JFA.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServicesFromAttribute(this IServiceCollection services)
    {
        foreach (var service in AttributeServices.GetServices())
        {
            switch (service.Lifetime)
            {
                case ELifetime.Transient:
                    service.BaseTypes.ForEach(baseType => services.AddTransient(baseType, service.Type)); break;
                case ELifetime.Scoped:
                    service.BaseTypes.ForEach(baseType => services.AddScoped(baseType, service.Type)); break;
                case ELifetime.Singleton:
                    service.BaseTypes.ForEach(baseType => services.AddSingleton(baseType, service.Type)); break;
            }
        }
    }
}