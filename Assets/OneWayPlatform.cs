using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public KeyCode dropKey = KeyCode.DownArrow; // key to fall through the platform

    private PlatformEffector2D platformEffector; // component platform effector
    public float fallDelay = 0.3f; //delay before the platform will be solid 
    private bool isFalling = false; // p1 falling or not

    private void Start()
    {
        // get the platformeffector2D
        platformEffector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        //change the angle of the platform when the key is pressed 
        if (Input.GetKey(dropKey) && !isFalling)
        {
            StartCoroutine(FallThroughPlatform()); 
        }
    }
    private IEnumerator FallThroughPlatform()
    {
        platformEffector.rotationalOffset = 180f; // one way
        isFalling = true;

        yield return new WaitForSeconds(fallDelay); // wait for the dealy before the platform will be solid again

        platformEffector.rotationalOffset = 0f;
        isFalling = false;//reinitialize the platform
    }
}

    //public bool coll; //collision true or false when we're colliding the platform 
    //public PlatformEffector2D platform; // control the surface arc of the platform 

    //public void Update()
    //{
    //    if (coll && Input.GetKey(KeyCode.S)) //colliding with the platform and the key that you want to drop 
    //    {
    //        platform.surfaceArc = 0f; //fall through the platform 
    //        StartCoroutine(Wait()); //delay to wait for the player to actually drop through the platform 
    //        Debug.Log("S works"); 
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //        coll = true; //detection whent we're colliding with the platform 
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    coll = false; //detection whent we're not colliding with the platform 
    //}

    //IEnumerator Wait() // platform solid again 
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    platform.surfaceArc = 125f;
    //    Debug.Log("Fall"); 
    //}







//    private GameObject currentFloor;          // we're currently standing on 

//    [SerializeField] private BoxCollider2D P1Collider; //reference to the P1's collider 

//    //private PlatformEffector2D effector;
//    //public float waitTime; // wait for the platform change of degrees 
//    void Start()
//    {
//        //effector = GetComponent<PlatformEffector2D>();
//    }


//    void Update()
//    {
//        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // check if the key has been released 
//        //{
//        //    waitTime = 0.5f; //time back to 0.5
//        //}
//        if (Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.DownArrow)) // check if the key was pressed
//        {
//            if (currentFloor != null)
//            {
//                StartCoroutine(DisableCollision());
//            }
//            //if(waitTime <= 0)
//            //{
//            //    effector.rotationalOffset = 180f; // if it is effectors rotationoffsets equal to 180 degrees and let go the player 
//            //    waitTime = 0.5f;

//            //}
//            //else
//            //{
//            //    waitTime -= Time.deltaTime; //hold down the keydown and the time isn't yet lace or equal to 0, slowly decrease the value 
//            //}
//            //if (Input.GetButtonDown("Jump"))
//            //{
//            //    effector.rotationalOffset = 0f; // rotation back to 0 degrees 
//            //}
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if(collision.gameObject.CompareTag("Floor"))
//        {
//            currentFloor = collision.gameObject; // set one-way plat with our currentonewayplat to the collided object 
//        }

//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if(collision.gameObject.CompareTag("Floor"))
//        {
//            currentFloor = null; // stop colliding we want to set current one way plat to null 
//        }

//    }

//    private IEnumerator DisableCollision() //coroutine is a function that can suspend its execution
//    {
//        BoxCollider2D platformCollider = currentFloor.GetComponent<BoxCollider2D>();

//        Physics2D.IgnoreCollision(P1Collider, platformCollider); //ignore the collision btw the player's collider and platform's collider 
//        yield return new WaitForSeconds(0.25f); //p1 wait an amount of time to fall through the platform
//        Physics2D.IgnoreCollision(P1Collider, platformCollider, false); // no longer ignore the collision 

//        Debug.Log("Corona"); 
//    }