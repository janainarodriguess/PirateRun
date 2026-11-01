using UnityEngine;

public class FixedX : MonoBehaviour
{
    float startX;
    Rigidbody2D rb;

    void Start()
    {
        startX = transform.position.x;
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        Vector3 pos = transform.position;
        pos.x = startX;
        transform.position = pos;
    }
}