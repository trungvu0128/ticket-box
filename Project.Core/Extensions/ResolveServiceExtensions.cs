using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Project.Core.Attributes;
using System.Reflection;

namespace Project.Core.Extensions
{
    public static class ResolveServiceExtensions
    {
        /// <summary>
        /// Resolve all service have injector attribute (Injector namespace)
        /// </summary>
        /// <param name="services"></param>
        /// <param name="registerAssemblies"></param>
        public static void Resolve(this IServiceCollection services, Assembly[] registerAssemblies)
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
                    if (intefaces.Length == 0)
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
                    if (intefaces.Length == 0)
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
                    if (intefaces.Length == 0)
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
