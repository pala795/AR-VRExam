using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float projectileSpeed;

    public void Shooting()
    {
        Rigidbody instantiatedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.linearVelocity = transform.TransformDirection(new Vector3(0, 0,projectileSpeed));

    }
}
