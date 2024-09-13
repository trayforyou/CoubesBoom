using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Creater : MonoBehaviour
{
    [SerializeField] private List<Cube> cubes;

    private int _minCount = 2;
    private int _maxCount = 6;
    private int _success = 1;

    public event Action<Vector3> CubesCreated;

    private void OnEnable()
    {
        foreach (Cube cube in cubes)
            cube.Removed += TryCreateCubes;
    }

    private void TryCreateCubes(GameObject cube)
    {
        cube.GetComponent<Cube>().Removed -= TryCreateCubes;

        int convertToRandom = cube.GetComponent<Cube>().Chance + 1;
        int result = Random.Range(_success, convertToRandom);

        if (result == _success)
            CreateCubes(cube);
    }

    private void CreateCubes(GameObject cube)
    {
        Vector3 newCubesLocate = cube.transform.position;

        int convertToRandom = _maxCount + 1;
        int countCubes = UnityEngine.Random.Range(_minCount, convertToRandom);

        for (int i = 1; i <= countCubes; i++)
        {
            int halfSize = 2;
            

            GameObject newCube = Instantiate(cube, newCubesLocate, Quaternion.identity);

            Cube newCubeComponent = newCube.GetComponent<Cube>();
            
            newCube.SetActive(true);
            newCubeComponent.enabled = true;
            newCubeComponent.CutHalfChance();
            newCubeComponent.Removed += TryCreateCubes;

            Vector3 cutSize = newCube.transform.localScale / halfSize;

            newCube.transform.localScale = cutSize;
        }

        CubesCreated?.Invoke(newCubesLocate);
    }
}