using UnityEngine;
using System.Collections;

/// <summary>
/// You can use a script to initialize the state of a injected property.
/// If multiple scripts need to use the same instance of a injected property, 
/// you can configure the order in wich they will execute in Edit -> Project Settings -> Script Execution Order
/// </summary>
public class RandomNumberOfCubesUnityInterface : MonoBehaviour {

    [InjectedDependency] private INumberGenerator numberGenerator;

    public int min = 3;
    public int max = 10;

    void Start()
    {
        this.InjectDependencies();

        numberGenerator.Min = min;
        numberGenerator.Max = max;
    }

    // Update is called once per frame
	void Update () {
	
	}
}
