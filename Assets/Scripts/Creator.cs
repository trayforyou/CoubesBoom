using UnityEngine;

public class Creater : MonoBehaviour
{
    private int _minCount = 2;
    private int _maxCount = 6;
    private int _success = 1;

    private void OnEnable()
    {
        Cube.Removed += TryCreateCubes;
    }

    private void OnDisable()
    {
        Cube.Removed -= TryCreateCubes;
    }

    private void TryCreateCubes(GameObject cube)
    {
        int convertToRandom = cube.GetComponent<Cube>().Chance + 1;
        int result = Random.Range(_success, convertToRandom);

        if (result == _success)
            CreateCubes(cube);
    }

    private void CreateCubes(GameObject cube)
    {
        int convertToRandom = _maxCount + 1;

        int countCubes = Random.Range(_minCount, convertToRandom);

        for (int i = 1; i <= countCubes; i++)
        {
            int halfSize = 2;

            GameObject newCube = Instantiate(cube,cube.transform.position, Quaternion.identity);

            newCube.SetActive(true);
            newCube.GetComponent<Cube>().enabled = true;
            newCube.GetComponent<Cube>().CutHalfChance();

            Vector3 cutSize = newCube.transform.localScale / halfSize;

            newCube.transform.localScale = cutSize;
        }
    }
}