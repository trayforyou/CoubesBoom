using UnityEngine;

public class Detonator : MonoBehaviour
{
    private float _explosionForce = 500;

    private void OnEnable()
    {
        Cube.Removed += Detonate;
    }

    private void OnDisable()
    {
        Cube.Removed -= Detonate;
    }

    private void Detonate(GameObject cube)
    {
        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, 0);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, 0);
            }
        }
    }
}
