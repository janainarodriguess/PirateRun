using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 3f;
    public int index = 0;

    float width;
    float startX;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        startX = transform.position.x;
        transform.position += new Vector3(index * width, 0, 0);
        sr.flipX = (index % 2 == 1);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < startX - width * 1.5f)
        {
            transform.position += new Vector3(width * 4f, 0, 0);
        }
    }
}