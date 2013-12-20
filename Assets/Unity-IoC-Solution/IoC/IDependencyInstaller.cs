using Autofac;

public interface IDependencyInstaller
{
    void ConfigureDependencies(ContainerBuilder builder);
}