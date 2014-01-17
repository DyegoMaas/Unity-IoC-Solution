using Autofac;

namespace Myth.IoC
{
    public interface IDependencyInstaller
    {
        void ConfigureDependencies(ContainerBuilder builder);
    }
}