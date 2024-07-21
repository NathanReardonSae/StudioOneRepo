using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float jumpForce = 30f;
    public float slideSpeed = 10f;
    public float slideDuration = 0.4f;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask groundMask;
    public LayerMask wallMask;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool canDoubleJump;
    private bool isSliding;
    private float slideTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ensure groundCheck and wallCheck are properly positioned
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to CharacterMovement script!");
        }
        if (wallCheck == null)
        {
            Debug.LogError("WallCheck not assigned to CharacterMovement script!");
        }
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);
        Debug.Log(" is Grounded: " + isGrounded);

        // Wall check
        float checkRadius = 0.5f;
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, wallMask);
        Debug.Log("Is Touching Wall: " + isTouchingWall);

        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump(jumpForce);
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && canDoubleJump && !isTouchingWall)
        {
            Jump(jumpForce);
            canDoubleJump = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isTouchingWall)
        {
            WallJump();
        }

        // Sliding
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
            StartSlide();
        }

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer <= 0f)
            {
                StopSlide();
            }
        }
    }

    void Jump(float jumpForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void WallJump()
    {
        float wallJumpDirection = isTouchingWall ? 1f : -1f; // Jump away from the wall
        rb.velocity = new Vector2(wallJumpDirection * moveSpeed, jumpForce);
    }

    void StartSlide()
    {
        isSliding = true;
        slideTimer = slideDuration;

        // Adjust character scale and speed for slide
        transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
        moveSpeed = slideSpeed;
    }

    void StopSlide()
    {
        isSliding = false;
        transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
        moveSpeed = 5f; // Reset move speed after slide
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false; // Reset double jump
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

