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

    private void TryCreateCubes(Cube prefab, Vector3 currentPosition, Vector3 currentScale, int chance)
    {
        int convertToRandom = chance + 1;
        int checker = Random.Range(_success, convertToRandom);


        Debug.Log(chance + " Шанс");

        if (checker == _success)
            CreateCubes(prefab, currentPosition,currentScale);
    }

    private void CreateCubes(Cube _prefab, Vector3 currentPosition, Vector3 _currentScale)
    {
        int convertToRandom = _maxCount + 1;

        int countCubes = Random.Range(_minCount, convertToRandom);

        Debug.Log(countCubes + "Количество кубов");

        for (int i = 1; i <= countCubes; i++)
        {
            Cube newCube = Instantiate(_prefab, currentPosition, Quaternion.identity);

            newCube.GetComponent<Cube>().CutChance();

            newCube.gameObject.SetActive(true);

            newCube.enabled = true;

            Vector3 cutSize = _currentScale / 2;

            newCube.transform.localScale = cutSize;
        }
    }
}