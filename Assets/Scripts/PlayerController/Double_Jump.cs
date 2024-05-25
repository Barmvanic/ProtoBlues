using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Jump : MonoBehaviour
{

    
    [SerializeField] MovementPlayer movementPlayer;

    private void OnCollisionEnter2D(Collision2D other) //hit different game object
    {
        if (other.gameObject.CompareTag("Floor")) // collide an object with a tag 
        {
            movementPlayer.doubleJump = false;
        }

    }

    private void OnCollisionExit2D(Collision2D other) //leaving the floor 
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            movementPlayer.doubleJump = true;
        }
    }
}
