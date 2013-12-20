using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    [InjectedDependency] private INumberGenerator numberGenerator;
    
    void Start()
    {
        this.InjectDependencies();

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