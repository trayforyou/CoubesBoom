using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chance = 1;
    [SerializeField] private int _explosionCoefficient = 3;

    private int _sizeMultiplayer = 2;

    public int Chance => _chance;
    public int ExplosionCoefficient => _explosionCoefficient;

    public event Action<Cube> Removed;
    
    public void Init()
    {
        CutHalfChance();
        MultiplyExplosionCoefficient();
    }

    private void CutHalfChance()
    {
        _chance = _chance * _sizeMultiplayer;
    }

    private void MultiplyExplosionCoefficient()
    {
        _explosionCoefficient *= _sizeMultiplayer;
    }

    private void OnEnable()
    {
        Paint();
    }

    private void OnDestroy()
    {
        Removed?.Invoke(GetComponent<Cube>());
    }

    private void Paint()
    {
        UnityEngine.Color newColor = UnityEngine.Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().materials[0].color = newColor;
    }
}
