using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_NotesBlanches : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] SpriteRenderer noterenderer;
    [SerializeField] Script_Timer timer;
    bool showed = false;

    void Start()
    {
        scoreText.color = new Color(1f, 1f, 1f, 0f);
        noterenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !showed)
        {
            showed = true; 
            timer.remainingTime += 10f;
            Debug.Log("+10");
            gameObject.GetComponent<Collider2D>().enabled = false;

            GameManager.Instance.noteCount++; // script changement de SCN QTE 
            Debug.Log("Note collected");

            StartCoroutine(HideScoreText("+10s"));
            noterenderer.color = new Color(1f, 1f, 1f, 0f);
            Debug.Log("-15s");

            


        }
    }

    IEnumerator HideScoreText(string textvar)
    {
        Debug.Log("show");
        scoreText.text = textvar;
        scoreText.color = new Color(0f, 1f, 0f, 1f);
        yield return new WaitForSeconds(1f);
        Debug.Log("hide");
        scoreText.color = new Color(1f, 1f, 1f, 0f);

        Destroy(gameObject);


    }
}

