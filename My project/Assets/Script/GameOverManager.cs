using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    bool isOver = false;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public void ShowGameOver()
    {
        if (isOver) return;
        isOver = true;

        if (finalScoreText != null && CoinManager.instance != null)
        {
            finalScoreText.text = "x " + CoinManager.instance.Score;
        }

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}