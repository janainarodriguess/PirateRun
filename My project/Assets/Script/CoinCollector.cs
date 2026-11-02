using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int Points = 1;
    private bool collected = false;
    private MoveLeft mover;
    private SpriteRenderer sr;

    private void Start()
    {
        mover = GetComponent<MoveLeft>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

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

            Reaparecer();
            collected = false;
        }
    }

    private void Reaparecer()
    {
        Camera cam = Camera.main;
        float halfW = cam.orthographicSize * cam.aspect;
        float rightEdge = cam.transform.position.x + halfW;
        float halfObj = (sr != null) ? sr.bounds.extents.x : 0.5f;

        float minGap = (mover != null) ? mover.minGap : 6f;
        float maxGap = (mover != null) ? mover.maxGap : 14f;

        Vector3 pos = transform.position;
        pos.x = rightEdge + halfObj + Random.Range(minGap, maxGap);
        transform.position = pos;
    }
}