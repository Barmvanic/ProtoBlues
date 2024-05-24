using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Jump : MonoBehaviour
{

    public bool isJumping;

    private void OnCollisionEnter2D(Collision2D other) //hit different game object
    {
        if (other.gameObject.CompareTag("Floor")) // collide an object with a tag 
        {
            isJumping = false; // not jumping
        }

    }

    private void OnCollisionExit2D(Collision2D other) //leaving the floor 
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true; // jumping
        }
    }
}
