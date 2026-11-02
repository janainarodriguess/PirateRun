using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 3f;
    public float minGap = 6f;
    public float maxGap = 14f;

    Camera cam;
    SpriteRenderer sr;

    void Start()
    {
        cam = Camera.main;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        float halfW = cam.orthographicSize * cam.aspect;
        float leftEdge = cam.transform.position.x - halfW;
        float rightEdge = cam.transform.position.x + halfW;
        float halfObj = (sr != null) ? sr.bounds.extents.x : 0.5f;

        if (transform.position.x + halfObj < leftEdge)
        {
            Vector3 pos = transform.position;
            pos.x = rightEdge + halfObj + Random.Range(minGap, maxGap);
            transform.position = pos;
        }
    }
}