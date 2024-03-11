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
