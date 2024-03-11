using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed; 
    public float jump;


    private float Move;

    public Rigidbody2D rb;

    public bool isJumping;
    bool doubleJump; 


    
   

    void Start()
    {
        Movement();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();      
    }

    void Movement ()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping) //p1 in the air whit the jump then the function will not work
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            doubleJump = true; //p1 jump while on the floor, double jump will be true 
        }
        else if (doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * 0.4f); //when doubleJump is true P1 will jump again & set at 40% of the first jump
            doubleJump = false; //after the second jump the doubleJump will be false 
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //hit different game object
    {
        if (other.gameObject.CompareTag("Floor")) // collide an object with a tag 
        { 
            isJumping = false; // not jumping
        }

    }

    private void OnCollisionExit2D(Collision2D other) //leaving the floor 
    {
        if(other.gameObject.CompareTag("Floor")) 
        { 
            isJumping = true; // jumping
        }
    }


}
