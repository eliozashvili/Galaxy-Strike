using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem playerDestructionVfx;

    private GameSceneManager _gameSceneManager;

    private void Start()
    {
        _gameSceneManager = FindAnyObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestructionVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
        _gameSceneManager.ReloadLevel();
    }
}
