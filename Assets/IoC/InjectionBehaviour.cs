using UnityEngine;

abstract public class InjectionBehaviour : MonoBehaviour
{
    void Start()
    {
        DependencyInjector.Instance.Inject(this);
        StartOverride();
    }

    protected abstract void StartOverride();
}