using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 3f;
    public int index = 0;            
    public int totalImages = 4;      
    public float overlap = 0.05f;    

    float step;
    float startX;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        float width = sr.bounds.size.x;
        step = width - overlap;

                Camera cam = Camera.main;
        float leftEdge = cam.transform.position.x - cam.orthographicSize * cam.aspect;
        startX = leftEdge + width / 2f;

        transform.position = new Vector3(startX + index * step, transform.position.y, transform.position.z);
        sr.flipX = (index % 2 == 1);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * GameSpeed.Multiplier * Time.deltaTime);

        if (transform.position.x < startX - step * 1.5f)
        {
            transform.position += new Vector3(step * totalImages, 0, 0);
        }
    }
}