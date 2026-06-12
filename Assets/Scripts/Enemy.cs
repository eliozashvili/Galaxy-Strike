using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionVfx;

    // Every single time this Enemy script is attached to a GameObject
    // with a non-trigger collider, and collision is with particle
    // it will activate this event
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destructionVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
