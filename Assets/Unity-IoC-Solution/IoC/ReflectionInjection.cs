using System;
using System.Linq;
using System.Reflection;
using Autofac;

namespace UnityIoCSolution
{
    /// <summary>
    /// Injects the dependencies via reflection
    /// </summary>
    public class ReflectionInjection : IDependencyInjector
    {
        private readonly IContainer container;

        public ReflectionInjection(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Finds all fields of the instance that have InjectedDependencyAttribute and injects the appropriate instances
        /// </summary>
        public void Inject(object instance)
        {
            var tipo = instance.GetType();

            var fields = tipo
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(prop => Attribute.IsDefined(prop, typeof(InjectedDependencyAttribute))).ToList();
            foreach (var field in fields)
            {
                field.SetValue(instance, container.Resolve(field.FieldType));
            }
        }
    }
}