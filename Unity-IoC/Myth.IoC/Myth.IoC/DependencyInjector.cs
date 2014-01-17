using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Myth.IoC;
using UnityEngine;
using System.Linq;

/// <summary>
/// The IoC container used is Autofac (version 2.6.3 for .NET 3.5). 
/// You can find more about Autofac in https://code.google.com/p/autofac/
/// </summary>
public class DependencyInjector : MonoBehaviour, IDependencyInjector
{
    private IContainer container;
    private IDependencyInjector dependencyInjector;

    public static DependencyInjector Instance;

    void Awake()
    {
        if (!Instance)
            Instance = this;
        else
        {
            Destroy(gameObject);
            
            Debug.Log("Only one instance of DepencyInjector can exist.");
            return;
        }

        container = RegisterDependencies();
        dependencyInjector = new ReflectionInjection(container);

        DontDestroyOnLoad(gameObject);
    }

    private IContainer RegisterDependencies()
    {
        var builder = new ContainerBuilder();

        var configurations = FindImplementationsOf<IDependencyInstaller>();
        foreach (var dependencyConfiguration in configurations)
        {
            dependencyConfiguration.ConfigureDependencies(builder);
        }

        return builder.Build();
    }

    private static IEnumerable<T> FindImplementationsOf<T>()
    {
        return from type in Assembly.GetCallingAssembly().GetTypes()
               where typeof(T).IsAssignableFrom(type) && type.IsClass
               select (T)Activator.CreateInstance(type);
    }

    public void Inject(object instance)
    {
        dependencyInjector.Inject(instance);
    }
}