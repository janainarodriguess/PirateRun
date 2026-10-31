using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pirata bateu no obstáculo!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}