using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneQTE : MonoBehaviour
{
    public Text messageText;
    public int requiredNoteCount = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.noteCount >= requiredNoteCount)
            {
                // Load the next scene if the player has collected the required number of notes
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


