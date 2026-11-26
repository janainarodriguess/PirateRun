using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Points = 1;
    public AudioClip somMoeda;
    [Range(0f, 1f)] public float volumeMoeda = 0.3f;
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            if (CoinManager.instance != null)
            {
                CoinManager.instance.AddPoints(Points);
            }

            if (somMoeda != null)
            {
                AudioSource.PlayClipAtPoint(somMoeda, Camera.main.transform.position, volumeMoeda);
            }

            Destroy(gameObject);
        }
    }
}