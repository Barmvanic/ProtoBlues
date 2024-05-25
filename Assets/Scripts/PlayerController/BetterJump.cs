using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{

    // **** GRAVITY PARAMETERS ***//
    public float fallMutiplier = 2.5f; // multiplier for gravity when falling down
    public float lowJumpMutiplier = 2f; // multiplier for gravity when releasing the jump button

    public Rigidbody2D rb;
    public float jumpForce = 10f; // Force applied for the jump
    private int jumpCount = 0; // Counter for jumps
    private bool isGrounded = false; // Check if the player is on the ground
    public Transform groundCheck; // Position to check if the player is on the ground
    public float groundCheckRadius = 0.1f; // Radius of the ground check
    public LayerMask groundLayer; // Layer of the ground

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0; // Reset jump count when grounded
        }

        // Jump logic
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < 2))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }

        // Apply gravity modifiers
        if (rb.velocity.y < 0) // vertical axis
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // holding button down 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMutiplier - 1) * Time.deltaTime;
        }
    }
}

