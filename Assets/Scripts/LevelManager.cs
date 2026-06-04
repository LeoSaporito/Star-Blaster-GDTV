using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        scoreKeeper.ResetScore();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOverScene", 2f));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}
