using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Cube))]

public class Cube : MonoBehaviour
{
    public static event Action<GameObject> Removed;

    [SerializeField] private int _chance = 1;

    private Cube _prefab;

    public int Chance => _chance;

    public void CutHalfChance()
    {
        int halfChance = 2;
        _chance = _chance * halfChance;
    }

    private void Awake()
    {
        _prefab = GetComponent<Cube>();
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        Paint();
    }

    private void OnDestroy()
    {
        Removed?.Invoke(this.gameObject);
    }

    private void Paint()
    {
        Color newColor = UnityEngine.Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().materials[0].color = newColor;
    }
}
