using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
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
        if(Input.GetButtonDown("FallThrough") && !isFalling)
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