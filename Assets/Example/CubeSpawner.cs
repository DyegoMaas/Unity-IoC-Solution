using UnityEngine;
using System.Collections;

// Your scripts must extend InjectionBehaviour in order to have automatic dependecy injection
public class CubeSpawner : InjectionBehaviour
{
    [InjectedDependency] private INumberGenerator numberGenerator;

    // You must implement StartOverride() because Start() is used in by the superclass InjectionBehaviour
    // StartOverride() is called at the end of Start(), after the dependencies were injected
    protected override void StartOverride()
    {
        int numberOfCubes = numberGenerator.GenerateNumberOfCubes();
        StartCoroutine(SpawnCubes(numberOfCubes));
    }

    IEnumerator SpawnCubes(int numberOfCubes)
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = this.transform;
            cube.transform.position = new Vector3(i * 1.5f, 0, 0);

            yield return new WaitForSeconds(.5f);
        }
    }

    void Update () {
	
	}
}