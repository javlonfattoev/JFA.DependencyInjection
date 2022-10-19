using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JFA.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddServicesFromAttribute(this IServiceCollection services)
    {
        foreach (var service in GetServices())
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

    public static List<ServiceInfo> GetServices(this AppDomain domain)
    {
        return domain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(Filter)
            .Select(GetService).ToList();
    }

    private static bool Filter(Type type) =>
        type.IsClass && 
        !type.IsAbstract &&
        type.GetCustomAttribute<ServiceAttribute>() != null;

    private static List<ServiceInfo> GetServices()
    {
        return AppDomain.CurrentDomain.GetServices();
    }

    private static ServiceInfo GetService(Type type)
    {
        var serviceInfo = new ServiceInfo
        {
            Type = type,
            Lifetime = type.GetCustomAttribute<ServiceAttribute>()!.Lifetime,
            BaseTypes = new List<Type>()
        };

        type.GetInterfaces()
            .ToList()
            .ForEach(serviceInfo.BaseTypes.Add);

        var baseType = type.BaseType;
        if (baseType != typeof(object))
            serviceInfo.BaseTypes.Add(baseType!);

        serviceInfo.BaseTypes.Add(type);
        return serviceInfo;
    }
}