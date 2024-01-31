using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Helper.Injector;
using System.Reflection;

namespace Shared.Helper
{
    public static class InjectorServiceCollectionExtension
    {
        public static void UseInjector(this IServiceCollection services, Assembly[] registerAssemblies)
        {
            var types = registerAssemblies.SelectMany(s => s.GetTypes()).Where(x =>
                x.IsDefined(typeof(ScopeAttribute))
                || x.IsDefined(typeof(SingletonAttribute))
                || x.IsDefined(typeof(TransientAttribute))
            );
            foreach (var type in types)
            {
                ServiceLifetime serviceLifetime = ServiceLifetime.Transient;
                if (type.IsDefined(typeof(ScopeAttribute)))
                {
                    serviceLifetime = ServiceLifetime.Scoped;
                }
                if (type.IsDefined(typeof(SingletonAttribute)))
                {
                    serviceLifetime = ServiceLifetime.Singleton;
                }
                InjectService(services, type, serviceLifetime);
            }
        }

        private static void InjectService(IServiceCollection services, Type type, ServiceLifetime serviceLifetime)
        {
            var intefaces = type.GetInterfaces();
            switch (serviceLifetime)
            {
                case ServiceLifetime.Scoped:
                    if (!intefaces.Any())
                    {
                        services.TryAddScoped(type);
                        break;
                    }
                    foreach (var inteface in intefaces)
                    {
                        services.TryAddScoped(inteface, type);
                    }
                    break;
                case ServiceLifetime.Singleton:
                    if (!intefaces.Any())
                    {
                        services.TryAddSingleton(type);
                        break;
                    }
                    foreach (var inteface in intefaces)
                    {
                        services.TryAddSingleton(inteface, type);
                    }
                    break;
                default:
                    if (!intefaces.Any())
                    {
                        services.TryAddTransient(type);
                        break;
                    }
                    foreach (var inteface in intefaces)
                    {
                        services.TryAddTransient(inteface, type);
                    }
                    break;
            }
        }
    }
}
