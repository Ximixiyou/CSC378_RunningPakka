using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float jumpForce = 10f;
    public float maxJumpHeight = 5f; // maximum height the ball can jump
    public int maxJumps = 1; // maximum number of jumps allowed
    private int jumps = 0; // number of jumps made so far
    public LayerMask groundLayer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity += movement * jumpForce * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && jumps < maxJumps)
        {
            float jumpHeight = transform.position.y + maxJumpHeight;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight - transform.position.y);
            jumps++;
        }

    }

    bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Platform"))
            {
                jumps = 0; // reset number of jumps
                return true;
            }
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumps = 0; // reset number of jumps
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
}
