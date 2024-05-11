using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    // **** GRAVITY PARAMETERS ***//
    public float fallMutiplier = 2.5f; // mutliply the gravity then P1 is falling down 
    public float lowJumpMutiplier = 2f; //release the jump button we're going to release jump gravity 

    public Rigidbody2D rb;
  


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   private void Update()

    {
        if (rb.velocity.y < 0) // vertical axis
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) //holding button down 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMutiplier - 1) * Time.deltaTime;
        }
    }

  
}
