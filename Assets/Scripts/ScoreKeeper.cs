using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }
    public void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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
