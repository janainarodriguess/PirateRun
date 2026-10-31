using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Points = 1;
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;
            Debug.Log("Moeda: " + name + " | posição da moeda: " + transform.position + " | tocou em: " + other.name + " | tamanho do collider: " + other.bounds.size, gameObject);

            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddPoints(Points);
            }

            Destroy(gameObject);
        }
    }
}