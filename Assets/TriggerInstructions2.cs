using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerInstructions2 : MonoBehaviour
{
    public TextMeshProUGUI instructionsText2;  // display in


    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
            instructionsText2.text = "You can fall through the platform with Y or down arrow.";
            StartCoroutine(ClearMessage());
        }
    }


    private IEnumerator ClearMessage()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        // Clear the message text
        instructionsText2.text = "";
    }
}

