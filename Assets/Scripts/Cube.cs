using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public static event Action<Cube, Vector3, Vector3, int> Removed;

    [SerializeField] private Vector3 _currentScale;
    [SerializeField] private Vector3 _currentPosition;
    [SerializeField] private int _chance = 1;

    private Cube _prefab;

    public void CutChance()
    {
        _chance = _chance * 2;
    }

    private void Start()
    {
        _prefab = GetComponent<Cube>();
    }

    private void Update()
    {
        _currentPosition = transform.position;
        _currentScale = transform.localScale;
    }

    private void OnEnable()
    {
        Paint();
    }

    private void OnDestroy()
    {
        Removed?.Invoke(_prefab, _currentPosition, _currentScale, _chance);
    }

    private void Paint()
    {
        Color newColor = UnityEngine.Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().materials[0].color = newColor;
    }
}
