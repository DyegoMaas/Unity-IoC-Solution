using Autofac;

public class ExampleInstaller : IDependencyInstaller
{
    public void ConfigureDependencies(ContainerBuilder builder)
    {
        builder.RegisterType<RandomNumberGenerator>().As<INumberGenerator>().SingleInstance();
    }
}