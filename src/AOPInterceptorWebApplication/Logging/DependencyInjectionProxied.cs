﻿using Castle.DynamicProxy;

namespace AOPInterceptorWebApplication.Logging;

public static class DependencyInjectionProxied
{
    public static void AddProxiedScoped<TInterface, TImplementation>
        (this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
    {
        services.AddScoped<TImplementation>();
        services.AddScoped(typeof(TInterface), serviceProvider =>
        {
            var proxyGenerator = serviceProvider
                .GetRequiredService<ProxyGenerator>();
            var actual = serviceProvider
                .GetRequiredService<TImplementation>();
            var interceptors = serviceProvider
                .GetServices<ILoggingInterceptor>()
                .ToArray();

            return proxyGenerator.CreateInterfaceProxyWithTarget(
                typeof(TInterface), actual, interceptors);
        });
    }

    public static void AddProxiedTransient<TInterface, TImplementation>
        (this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddTransient<TImplementation>();
        services.AddTransient(typeof(TInterface), serviceProvider =>
        {
            var proxyGenerator = serviceProvider
                .GetRequiredService<ProxyGenerator>();
            var actual = serviceProvider
                .GetRequiredService<TImplementation>();
            var interceptors = serviceProvider
                .GetServices<ILoggingInterceptor>()
                .ToArray();

            return proxyGenerator.CreateInterfaceProxyWithTarget(
                typeof(TInterface), actual, interceptors);
        });
    }

    public static void AddProxiedSingleton<TInterface, TImplementation>
        (this IServiceCollection services)
        where TInterface : class
        where TImplementation : class, TInterface
            {
                services.AddSingleton<TImplementation>();
                services.AddSingleton(typeof(TInterface), serviceProvider =>
                {
                    var proxyGenerator = serviceProvider
                        .GetRequiredService<ProxyGenerator>();
                    var actual = serviceProvider
                        .GetRequiredService<TImplementation>();
                    var interceptors = serviceProvider
                        .GetServices<ILoggingInterceptor>()
                        .ToArray();

                    return proxyGenerator.CreateInterfaceProxyWithTarget(
                        typeof(TInterface), actual, interceptors);
                });
            }

}
