using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneQTE : MonoBehaviour
{
    public static int noteCount = 0;

    public Text messageText;

    public static int successfulQTECount = 0; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene scene = SceneManager.GetActiveScene();

        if (collision.CompareTag("Player"))
        {
            noteCount++;

            // if P1 have the 4 notes 
            if (noteCount >= 4)
            {
                SceneManager.LoadScene("SCN_NIV3");
            }
            else
            {
                // show the text in UI
                messageText.text = "You don't have all the notes, Andy.";
                StartCoroutine(ClearMessage());
            }

        }


    }

    IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        messageText.text = ""; // Dissapear 
    }
}
