using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Hit();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Hit();
        }
    }

    void Hit()
    {
        if (GameOverManager.instance != null)
        {
            GameOverManager.instance.ShowGameOver();
        }
    }
}