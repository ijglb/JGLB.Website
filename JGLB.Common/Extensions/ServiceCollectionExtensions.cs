using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace JGLB.Common
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Service属性自动注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblys"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceAttribute(this IServiceCollection services, params Assembly[] assemblys)
        {
            var allAssembly = new List<Assembly>();
            if (assemblys == null)
            {
                allAssembly = GetAllAssembly();
            }
            else
            {
                allAssembly.AddRange(assemblys);
            }

            var types = allAssembly.SelectMany(t => t.GetTypes()).Where(t => t.IsClass && !t.IsAbstract && t.IsDefined(typeof(ServiceAttribute), false)).Select(t => new { Type = t, Lifetime = t.GetCustomAttribute<ServiceAttribute>()?.Lifetime }).ToList();

            foreach (var item in types)
            {
                Type? typeInterface = item.Type.GetInterfaces().FirstOrDefault();
                if (typeInterface == null)
                {
                    switch (item.Lifetime)
                    {
                        case ServiceLifetime.Singleton: services.TryAddSingleton(item.Type); break;
                        case ServiceLifetime.Scoped: services.TryAddScoped(item.Type); break;
                        case ServiceLifetime.Transient: services.TryAddTransient(item.Type); break;
                    }
                }
                else
                {
                    switch (item.Lifetime)
                    {
                        case ServiceLifetime.Singleton: services.TryAddSingleton(typeInterface, item.Type); break;
                        case ServiceLifetime.Scoped: services.TryAddScoped(typeInterface, item.Type); break;
                        case ServiceLifetime.Transient: services.TryAddTransient(typeInterface, item.Type); break;
                    }
                }
            }

            return services;
        }

        /// <summary>
        /// Service属性自动注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="regexStrs"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceAttribute(this IServiceCollection services, params string[] regexStrs) => services.AddServiceAttribute(GetAllAssembly(regexStrs).ToArray());

        private static List<Assembly> GetAllAssembly(params string[] regexStrs)
        {

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            HashSet<string> loadedAssemblies = new();

            foreach (var item in allAssemblies)
            {
                loadedAssemblies.Add(item.FullName!);
            }

            Queue<Assembly> assembliesToCheck = new();
            assembliesToCheck.Enqueue(Assembly.GetEntryAssembly()!);

            while (assembliesToCheck.Any())
            {
                var assemblyToCheck = assembliesToCheck.Dequeue();
                foreach (var reference in assemblyToCheck!.GetReferencedAssemblies())
                {
                    if (!loadedAssemblies.Contains(reference.FullName))
                    {
                        var assembly = Assembly.Load(reference);

                        assembliesToCheck.Enqueue(assembly);

                        loadedAssemblies.Add(reference.FullName);

                        allAssemblies.Add(assembly);
                    }
                }
            }
            if (regexStrs != null)
            {
                allAssemblies.RemoveAll(x => !regexStrs.Any(s => Regex.IsMatch(x.FullName ?? "", s)));
            }
            return allAssemblies;
        }
    }
}
