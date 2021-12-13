using Indimin.Challenge.Logging.Middlewares;
using Indimin.Challenge.Logging.Pipelines;
using Indimin.Challenge.Logging.Proxies;
using MediatR;
using Microsoft.AspNetCore.Builder;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LoggingConfiguration
    {
        public static IApplicationBuilder AddLoggingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoggingMiddleware>();
            return app;
        }
        public static IServiceCollection AddLogging(this IServiceCollection services, Assembly assemblyToScan)
        {
            services.DecorateWithDispatchProxy(assemblyToScan);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            return services;
        }

        private static IServiceCollection DecorateWithDispatchProxy(this IServiceCollection services, Assembly assemblyToScan)
        {
            if (assemblyToScan != null)
            {
                var allIntefaces = assemblyToScan.GetTypes()
                    .Where(t => !t.IsInterface && t.GetInterfaces().Any())
                    .SelectMany(x => x.GetInterfaces().Where(x => x.Namespace.Contains("Indimin.Challenge")))
                    .Distinct();


                foreach (var interfaceType in allIntefaces)
                {
                    Type proxy = typeof(LoggingProxy<>);
                    Type[] typeArgs = { interfaceType };
                    Type proxyWithInterface = proxy.MakeGenericType(typeArgs);

                    MethodInfo createMethod;
                    try
                    {
                        createMethod = proxyWithInterface
                            .GetMethods(BindingFlags.Public | BindingFlags.Static)
                            .First(info => !info.IsGenericMethod && info.ReturnType == interfaceType);
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new InvalidOperationException($"Looks like there is no static method in {proxyWithInterface} " +
                                                            $"which creates instance of {interfaceType} (note that this method should not be generic)", e);
                    }

                    var argInfos = createMethod.GetParameters();

                    // Save all descriptors that needs to be decorated into a list.
                    var descriptorsToDecorate = services
                        .Where(s => s.ServiceType == interfaceType)
                        .ToList();

                    if (descriptorsToDecorate.Count == 0)
                    {
                        throw new InvalidOperationException($"Attempted to Decorate services of type {interfaceType}, " +
                                                            "but no such services are present in ServiceCollection");
                    }

                    foreach (var descriptor in descriptorsToDecorate)
                    {
                        var decorated = ServiceDescriptor.Describe(
                            interfaceType,
                            sp =>
                            {
                                var decoratorInstance = createMethod.Invoke(null,
                                    argInfos.Select(
                                            info => info.ParameterType == (descriptor.ServiceType ?? descriptor.ImplementationType)
                                                ? sp.CreateInstance(descriptor)
                                                : sp.GetRequiredService(info.ParameterType))
                                        .ToArray());

                                return decoratorInstance;
                            },
                            descriptor.Lifetime);

                        services.Remove(descriptor);
                        services.Add(decorated);
                    }

                }


            }
            return services;
        }
        private static object CreateInstance(this IServiceProvider services, ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance != null)
            {
                return descriptor.ImplementationInstance;
            }

            if (descriptor.ImplementationFactory != null)
            {
                return descriptor.ImplementationFactory(services);
            }

            return ActivatorUtilities.GetServiceOrCreateInstance(services, descriptor.ImplementationType);
        }
    }
}
