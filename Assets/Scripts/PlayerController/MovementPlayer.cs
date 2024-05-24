using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed; 
    public float jump;
    [Range(1,10)]
    public float jumpVelocity; 


    private float Move;

    public Rigidbody2D rb;
    [SerializeField] Animator animator; 

    //[SerializeField] Double_Jump Pieds;
    //bool doubleJump;
    bool facingRight = true;
    bool isGrounded = false;
   

    //CHECKPOINT
    private Transform LastCheckpoint = null;

    // LayerMask pour vérifier le sol
    public LayerMask groundLayer;
    public Transform groundCheck;
    private float groundCheckRadius = 0.2f;

    //NOTECOUNT 
    public Inventory_notes nc; //notecount

   



    void Start()
    {
        Movement();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
            
        }

      
    }

    void Movement ()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);


        if (animator != null)
        {
            animator.SetBool("isWalking", Mathf.Abs(Move) > 0.01f);
        }

        if (Input.GetButtonDown("Jump") && isGrounded /*&& !Pieds.isJumping*/) //p1 in the air whit the jump then the function will not work
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            StartCoroutine(JumpTrigger());

            /* doubleJump = true;*/ //p1 jump while on the floor, double jump will be true 
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
            


        }
        else if (Input.GetButtonDown("Jump") /*&& doubleJump*/)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * 0.3f); //when doubleJump is true P1 will jump again & set at 40% of the first jump
            /* doubleJump = false;*/ //after the second jump the doubleJump will be false 
            animator.SetBool("DoubleJump", true);
            StartCoroutine(DoubleJump());
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight; 

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Checkpoint"))
        {
            Transform CurrentCheckpoint = collision.gameObject.transform;

            Checkpoint(CurrentCheckpoint);

            collision.GetComponent<CheckpointSystem>().CheckpointFeedback();

            Debug.Log("collidedDEAD");

        }

        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
            nc.notes++; 
        }
    }

    

    private void Checkpoint(Transform checkpointTransform)
    {
        LastCheckpoint = checkpointTransform; 
    }

    IEnumerator JumpTrigger()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("isJumping", true);
    }

    IEnumerator DoubleJump()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("DoubleJump", false);
    }
}
