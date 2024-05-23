using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TriggerInstructions: MonoBehaviour
{

    public TextMeshProUGUI instructionsText;  // display in
    

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player"))
        {
           instructionsText.text = "For jump, press A or space."; 
           StartCoroutine(ClearMessage());
        }
    }


    private IEnumerator ClearMessage()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);
        // Clear the message text
        instructionsText.text = "";
    }
}


