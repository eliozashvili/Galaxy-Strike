using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDestructionVfx;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestructionVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
