using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneQTE : MonoBehaviour
{
    public Text messageText;
    public int requiredNoteCount = 3;
    private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameManager.noteCount >= requiredNoteCount)
            {
                // Load the next scene if the player has collected the required number of notes
                SceneManager.LoadScene("SCN_QTE");
            }
            else
            {
                // Show the message in the UI
                messageText.text = "You don't have all the notes, Dummy.";
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


