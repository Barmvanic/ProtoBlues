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

    [SerializeField] Double_Jump Pieds;
    bool doubleJump;
    bool facingRight = true;

    
  


    void Start()
    {
        Movement();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            Flip(); 
        }
        if (Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            Flip(); 
        }

    }

    void Movement ()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && !Pieds.isJumping) //p1 in the air whit the jump then the function will not work
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            doubleJump = true; //p1 jump while on the floor, double jump will be true 
        }
        else if (Input.GetButtonDown("Jump") && doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * 0.3f); //when doubleJump is true P1 will jump again & set at 40% of the first jump
            doubleJump = false; //after the second jump the doubleJump will be false 
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight; 

    }

  

}
