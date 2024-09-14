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

    public event Action<Cube> CubesRemoved;

    private void OnEnable()
    {
        foreach (Cube cube in cubes)
            cube.Removed += TryCreateCubes;
    }

    private void TryCreateCubes(Cube cube)
    {
        cube.Removed -= TryCreateCubes;

        int convertToRandom = cube.Chance + 1;
        int result = Random.Range(_success, convertToRandom);

        if (result == _success)
        {
            CreateCubes(cube);
        }
        else
        {
            CubesRemoved?.Invoke(cube);
        }
    }

    private void CreateCubes(Cube cube)
    {
        Vector3 newCubesLocate = cube.transform.position;

        int convertToRandom = _maxCount + 1;
        int countCubes = Random.Range(_minCount, convertToRandom);

        for (int i = 1; i <= countCubes; i++)
        {
            int halfSize = 2;

            Cube newCube = Instantiate(cube, newCubesLocate, Quaternion.identity);

            newCube.gameObject.SetActive(true);
            newCube.enabled = true;
            newCube.Removed += TryCreateCubes;
            newCube.Init();

            Vector3 cutSize = newCube.transform.localScale / halfSize;
            newCube.transform.localScale = cutSize;
        }
    }
}