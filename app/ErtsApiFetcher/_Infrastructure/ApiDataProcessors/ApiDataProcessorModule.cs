using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace ErtsApiFetcher._Infrastructure.ApiDataProcessors {
    public static class ApiDataProcessorModule {
        private static readonly Type processorType = typeof(IApiDataProcessor<>);

        public static void AddApiDataProcessors(this IServiceCollection services) {
            services.AddScoped<ApiDataProcessorExecutor>();

            Assembly.GetAssembly(typeof(ApiDataProcessorExecutor))
                .GetTypes()
                .Where(p => p.IsClass && !p.IsAbstract && p.IsAssignableToGenericType(processorType))
                .ToList()
                .ForEach(RegisterActionHandler);

            void RegisterActionHandler(Type type) {
                services.AddScoped(processorType.MakeGenericType(type.BaseType.GetGenericArguments()), type);
            }
        }
    }

    public static class TypeHelper {
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType) {
            if (givenType == null || genericType == null) {
                return false;
            }

            return givenType == genericType
              || givenType.MapsToGenericTypeDefinition(genericType)
              || givenType.HasInterfaceThatMapsToGenericTypeDefinition(genericType)
              || givenType.BaseType.IsAssignableToGenericType(genericType);
        }

        private static bool HasInterfaceThatMapsToGenericTypeDefinition(this Type givenType, Type genericType) =>
            givenType
              .GetInterfaces()
              .Where(it => it.IsGenericType)
              .Any(it => it.GetGenericTypeDefinition() == genericType);

        private static bool MapsToGenericTypeDefinition(this Type givenType, Type genericType) =>
            genericType.IsGenericTypeDefinition
              && givenType.IsGenericType
              && givenType.GetGenericTypeDefinition() == genericType;
    }
}
