using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private GameObject currentFloor;          // we're currently standing on 

    [SerializeField] private BoxCollider2D P1Collider; //reference to the P1's collider 

    //private PlatformEffector2D effector;
    //public float waitTime; // wait for the platform change of degrees 
    void Start()
    {
        //effector = GetComponent<PlatformEffector2D>();
    }

    
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // check if the key has been released 
        //{
        //    waitTime = 0.5f; //time back to 0.5
        //}
            if (Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.DownArrow)) // check if the key was pressed
        {
            if (currentFloor != null)
            {
                StartCoroutine(DisableCollision());
            }
            //if(waitTime <= 0)
            //{
            //    effector.rotationalOffset = 180f; // if it is effectors rotationoffsets equal to 180 degrees and let go the player 
            //    waitTime = 0.5f;
           
            //}
            //else
            //{
            //    waitTime -= Time.deltaTime; //hold down the keydown and the time isn't yet lace or equal to 0, slowly decrease the value 
            //}
            //if (Input.GetButtonDown("Jump"))
            //{
            //    effector.rotationalOffset = 0f; // rotation back to 0 degrees 
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            currentFloor = collision.gameObject; // set one-way plat with our currentonewayplat to the collided object 
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            currentFloor = null; // stop colliding we want to set current one way plat to null 
        }
        
    }

    private IEnumerator DisableCollision() //coroutine is a function that can suspend its execution
    {
        BoxCollider2D platformCollider = currentFloor.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(P1Collider, platformCollider); //ignore the collision btw the player's collider and platform's collider 
        yield return new WaitForSeconds(0.25f); //p1 wait an amount of time to fall through the platform
        Physics2D.IgnoreCollision(P1Collider, platformCollider, false); // no longer ignore the collision 

        Debug.Log("Corona"); 
    }
}
