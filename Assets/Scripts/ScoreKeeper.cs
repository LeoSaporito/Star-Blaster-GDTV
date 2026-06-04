using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

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
