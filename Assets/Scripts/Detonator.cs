using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private Creater creater;
    [SerializeField] private float _explosionForce = 1500000000;
    [SerializeField] private float _explosionRadius = 15000000;

    private void OnEnable()
    {
        creater.CubesRemoved += Detonate;
    }

    private void OnDisable()
    {
        creater.CubesRemoved -= Detonate;
    }

    private void Detonate(Cube cube)
    {
        Vector3 explosionPoint = cube.transform.position;
        float currentExplosionForce = _explosionForce * cube.ExplosionMultiplyer;
        float currentExplosionRadius = _explosionRadius * cube.ExplosionMultiplyer;

        Collider[] colliders = Physics.OverlapSphere(explosionPoint, currentExplosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(currentExplosionForce, explosionPoint, currentExplosionRadius);
            }
        }
    }
}
