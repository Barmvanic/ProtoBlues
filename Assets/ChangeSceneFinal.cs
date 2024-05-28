using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ChangeSceneFinal : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public int requiredNoteCount = 5;

    private void Start()
    {
        // Check if messageText is assigned in the inspector
        if (messageText == null)
        {
            Debug.LogError("Message Text is not assigned in the inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance.noteCount >= requiredNoteCount)
            {
                // Load the next scene if the player has collected the required number of notes
                SceneManager.LoadScene("SCN_DEVIL_CINEMATIC");
            }
            else
            {
                // Show the message in the UI if messageText is assigned
                if (messageText != null)
                {
                    messageText.text = "Still, don't have all the notes.";
                    StartCoroutine(ClearMessage());
                }
            }
        }
    }

    private IEnumerator ClearMessage()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);
        // Clear the message text if messageText is assigned
        if (messageText != null)
        {
            messageText.text = "";
        }
    }
}


