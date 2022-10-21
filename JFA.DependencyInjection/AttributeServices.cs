using System.Reflection;

namespace JFA.DependencyInjection;

internal static class AttributeServices
{
    internal static List<ServiceInfo> GetServices(this AppDomain domain)
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

    internal static List<ServiceInfo> GetServices()
    {
        return AppDomain.CurrentDomain.GetServices();
    }

    internal static ServiceInfo GetService(Type type)
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