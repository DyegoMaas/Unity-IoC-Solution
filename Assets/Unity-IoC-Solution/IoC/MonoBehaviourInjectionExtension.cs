using UnityEngine;

public static class MonoBehaviourInjectionExtension
{
    public static void InjectDependencies(this MonoBehaviour instance)
    {
        DependencyInjector.Instance.Inject(instance);
    }
}