using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float jumpForce = 1f;
    public float maxJumpHeight = 1f; // maximum height the ball can jump
    public int maxJumps = 1; // maximum number of jumps allowed
    private int jumps = 0; // number of jumps made so far
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Add a reference to the SpriteRenderer component
    public Animator animator;
    private AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput * jumpForce, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && jumps < maxJumps)
        {
            float jumpVelocity = Mathf.Sqrt(2 * jumpForce * maxJumpHeight);
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            jumps++;

            jumpSound.Play(); // Play the jump sound
        }
    }


    bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
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
        if (collision.gameObject.CompareTag("Platform"))
        {
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.normal.y > 0.7f) // Check if collision occurs at the bottom of the character
            {
                jumps = 0; // Reset number of jumps
            }
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }

    // Add this function to change the sprite based on the player's velocity
    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // The sprite faces right
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // The sprite faces left
        }
    }
}
