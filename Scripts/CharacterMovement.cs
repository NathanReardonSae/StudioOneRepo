using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 20f;           // The speed at which the Player will move.
    public float jumpForce = 30f;           // The force at which the player will jump.
    public float doubleJumpForce = 25f;     // The force for double jumping.
    public Transform groundCheck;           // Transform to check for contact with ground.
    public LayerMask groundMask;            // Layer mask for ground objects.

    private Rigidbody2D rb;
    private bool isGrounded;                // Flag to check if the player is on the ground.
    private bool canJump;                   // Flag to check if the player can jump.
    private bool canDoubleJump;             // Flag to check if the player can perform a double jump.
    private bool hasDoubleJumped;           // Flag to check if the player has performed a double jump.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = true;
        canDoubleJump = true;
        hasDoubleJumped = false;
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);

        // Handle movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jumping
        if (isGrounded)
        {
            // Reset jump states when grounded
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

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }
}







