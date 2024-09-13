using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private Creater creater;
    [SerializeField] private float _explosionForce = 500;

    private void OnEnable()
    {
        creater.CubesCreated += Detonate;
    }

    private void OnDisable()
    {
        creater.CubesCreated -= Detonate;
    }

    private void Detonate(Vector3 explosionPoint)
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPoint, 0);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, explosionPoint, 0);
            }
        }
    }
}
