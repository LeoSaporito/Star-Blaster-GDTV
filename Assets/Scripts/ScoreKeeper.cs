using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    int score;

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetCurrentScore()
    {
        return score;
    }

    public void AddToScore(int addScore)
    {
        score += addScore;

        score = Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
