using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PirateRunner : MonoBehaviour
{
    [Header("Movimento")]
    public float runSpeed = 5f;
    public float jumpForce = 8f;

    [Header("Chão")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);
    }
}