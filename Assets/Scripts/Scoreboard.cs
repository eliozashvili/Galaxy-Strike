using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int _score;

    public void CountScore(int amount)
    {
        _score += amount;
        scoreText.text = _score.ToString();
    }
}
