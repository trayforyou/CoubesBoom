using UnityEngine;

public class Detonator : MonoBehaviour
{
    private float _explosionForce = 5000;

    private void OnDestroy()
    {
        Detonate();
    }

    private void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce,transform.position, 0);
            }
        }
    }
}
