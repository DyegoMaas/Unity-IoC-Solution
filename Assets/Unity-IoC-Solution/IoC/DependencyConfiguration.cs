using Autofac;

public class DependencyConfiguration
{
    private readonly ContainerBuilder containerBuilder;

    public DependencyConfiguration(ContainerBuilder containerBuilder)
    {
        this.containerBuilder = containerBuilder;
    }

    public void ConfigureDependencies()
    {
        // here you configure the all the dependencies and its implementations
        containerBuilder.RegisterType<RandomNumberGenerator>().As<INumberGenerator>().SingleInstance();
    }
}