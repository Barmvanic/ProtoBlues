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

    //[SerializeField] Double_Jump Pieds;
    //bool doubleJump;
    bool facingRight = true;

    //CAMERA
    private float _fallSpeedYDampingChangeThreshold;

    //CHECKPOINT
    private Transform LastCheckpoint = null;
    





    void Start()
    {
        Movement();

        rb = GetComponent<Rigidbody2D>();

        _fallSpeedYDampingChangeThreshold = CameraManager.instance._fallSpeddYDamplingChangeTreshold; 


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

        // if we are falling past a certain speed threshold 
        if(rb.velocity.y <_fallSpeedYDampingChangeThreshold && !CameraManager.instance.IsLerpingYDamping && !CameraManager.instance.LerpedFromPlayerFalling)
        {
            CameraManager.instance.LerpYDamping(true); 
        }
        // if we are standing still or moving up 
        if (rb.velocity.y >= 0f && !CameraManager.instance.IsLerpingYDamping && CameraManager.instance.LerpedFromPlayerFalling)
        {
            //reset so it can be called again 

            CameraManager.instance.LerpedFromPlayerFalling = false;

            CameraManager.instance.LerpYDamping(false);
        }

    }

    void Movement ()
    {
        Move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);


        if (Input.GetButtonDown("Jump") /*&& !Pieds.isJumping*/) //p1 in the air whit the jump then the function will not work
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
           /* doubleJump = true;*/ //p1 jump while on the floor, double jump will be true 
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity; 
        }
        else if (Input.GetButtonDown("Jump") /*&& doubleJump*/)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * 0.3f); //when doubleJump is true P1 will jump again & set at 40% of the first jump
           /* doubleJump = false;*/ //after the second jump the doubleJump will be false 
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

        }
    }

    private void Checkpoint(Transform checkpointTransform)
    {
        LastCheckpoint = checkpointTransform; 
    }


}