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

    private void Detonate(Cube cube, Vector3 cubePosition, Vector3 currentScale, int chance)
    {
        Collider[] colliders = Physics.OverlapSphere(cubePosition, 0);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionForce, cubePosition, 0);
            }
        }
    }
}
