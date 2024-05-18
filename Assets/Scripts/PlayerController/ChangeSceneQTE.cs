using System.Collections;
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

            // Check if player has collected the required number of notes
            if (noteCount >= 4)
            {
                // Load the next scene
                SceneManager.LoadScene("SCN_NIV3");
            }
            else
            {
                // Show the message in the UI
                messageText.text = "You don't have all the notes, Andy.";
                StartCoroutine(ClearMessage());
            }
        }
    }

    private IEnumerator ClearMessage()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);
        // Clear the message text
        messageText.text = "";
    }
}

