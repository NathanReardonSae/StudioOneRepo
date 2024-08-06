using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 20f;           // The speed at which the Player will move.
    public float jumpForce = 30f;           // The force at which the player will jump.
    public float doubleJumpForce = 25f;     // The force for double jumping.
    public Transform groundCheck;           // Transform to check for contact with ground.
    public Transform wallCheck;             // Transform to check for contact with walls.
    public LayerMask groundMask;            // Layer mask for ground objects.
    public LayerMask wallMask;              // Layer mask for wall objects.

    private Rigidbody2D rb;
    private bool isGrounded;                // Flag to check if the player is on the ground.
    private bool isTouchingWall;            // Flag to check if the player is touching a wall.
    private bool canJump;                   // Flag to check if the player can jump.
    private bool canDoubleJump;             // Flag to check if the player can perform a double jump.
    private bool hasDoubleJumped;           // Flag to check if the player has performed a double jump.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        canDoubleJump = true;
    }

    void Update()
    {
        // Ground and wall check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, 0.5f, wallMask);

        // Handle movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (isGrounded)
        {
            canJump = true;
            canDoubleJump = true;
            hasDoubleJumped = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                Jump(jumpForce);
                canJump = false;
            }
            else if (canDoubleJump && !hasDoubleJumped)
            {
                Jump(doubleJumpForce);
                canDoubleJump = false;
                hasDoubleJumped = true;
            }
        }
    }

    void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canJump = true;
            canDoubleJump = true;
            hasDoubleJumped = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}






