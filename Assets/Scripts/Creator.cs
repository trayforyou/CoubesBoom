using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private Vector3 _currentScale;
    [SerializeField] private Vector3 _currentPosition;

    private GameObject _cubePrefab;
    private int _minCount = 2;
    private int _maxCount = 6;
    private int Chance = 1;

    private void Start()
    {
        _cubePrefab = Resources.Load<GameObject>("Cube");
    }

    private void OnEnable()
    {
        Paint();
    }

    private void Update()
    {
        _currentPosition = transform.position;
        _currentScale = transform.localScale;
    }

    private void OnDestroy()
    {
        TryCreateCubes();
    }

    private void Paint()
    {
        Color newColor = Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().materials[0].color = newColor;
    }

    private void TryCreateCubes()
    {
        int convertToRandom = Chance + 1;
        int success = 1;
        int checker = Random.Range(success, convertToRandom);

        if (checker == success)
            CreateCubes();
    }

    private void CreateCubes()
    {
        int convertToRandom = _maxCount + 1;

        int countCubes = Random.Range(_minCount, convertToRandom);

            Debug.Log(countCubes + "Количество кубов");

        for(int i = 1; i <= countCubes; i++)
        {
            GameObject newCube = Instantiate(_cubePrefab, _currentPosition, Quaternion.identity);

            Vector3 newSize = _currentScale / 2;
            newCube.transform.localScale = newSize;
            int newChance = Chance * 2;
            newCube.GetComponent<Creater>().Chance = newChance;
        }
    }
}