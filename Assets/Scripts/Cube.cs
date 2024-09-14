using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Cube))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chance = 1;
    [SerializeField] private int _explosionCoefficient = 1;

    public int Chance => _chance;
    public int ExplosionMultiplyer => _explosionCoefficient;

    public event Action<GameObject> Removed;
    
    public void CutHalfChance()
    {
        int halfChance = 2;
        _chance *= halfChance;
    }

    public void MultiplyExplosionCoefficient()
    {
        int multiplayer = 2;
        _explosionCoefficient *= multiplayer;
    }

    private void OnEnable()
    {
        Paint();
    }

    private void OnDestroy()
    {
        Removed?.Invoke(gameObject);
    }

    private void Paint()
    {
        Color newColor = UnityEngine.Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().materials[0].color = newColor;
    }
}
