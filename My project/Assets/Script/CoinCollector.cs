using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Points = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moeda coletada!");

            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddPoints(Points);
            }

            Destroy(gameObject);
        }
    }
}