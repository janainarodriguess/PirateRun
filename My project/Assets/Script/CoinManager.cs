
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AtualizarTexto();
    }

    public void AddPoints(int points)
    {
        score += points;
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        if (scoreText != null)
        {
            scoreText.text = "Moedas: " + score;
        }
        else
        {
            Debug.LogWarning("Score Text não está ligado no CoinManager!");
        }
    }
}