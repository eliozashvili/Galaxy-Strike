using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Start()
    {
        var amountOfPlayers = FindObjectsByType<MusicPlayer>().Length;

        if (amountOfPlayers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
