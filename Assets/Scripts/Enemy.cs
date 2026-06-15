using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem destructionVfx;
    [SerializeField] private int hitPoints;
    [SerializeField] private int scoreValue;

    private Scoreboard _scoreboard;

    private void Start()
    {
        _scoreboard = FindAnyObjectByType<Scoreboard>();
    }

    // Every single time this Enemy script is attached to a GameObject
    // with a non-trigger collider, and collision is with particle
    // it will activate this event
    private void OnParticleCollision(GameObject other)
    {
        ProcessHitPoints();
    }

    private void ProcessHitPoints()
    {
        hitPoints--;

        if (hitPoints > 0) return;

        _scoreboard.CountScore(scoreValue);
        Instantiate(destructionVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
