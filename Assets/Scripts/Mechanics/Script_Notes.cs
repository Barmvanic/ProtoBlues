using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[System.Serializable]
//public class SoundNotes // permits to set up the key with the image 
//{
   
//    public AudioClip sound; // the sound associated with this QTE
//}
public class Script_Notes : MonoBehaviour
{
    [SerializeField] Script_Timer timer;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] SpriteRenderer noterenderer;

    bool showed = false;

    // Start is called before the first frame update
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
            timer.remainingTime -= 15f;

            StartCoroutine(HideScoreText("-15s"));
            noterenderer.color = new Color(1f, 1f, 1f, 0f);
            Debug.Log("-15s");

        }
    }

    private void ShowScoreText(string textvar)
    {
        StartCoroutine(HideScoreText(textvar));

    }

    IEnumerator HideScoreText(string textvar)
    {
        Debug.Log("show");
        scoreText.text = textvar;
        scoreText.color = new Color(1f, 0f, 0f, 1f);
        yield return new WaitForSeconds(1f);
        Debug.Log("hide");
        scoreText.color = new Color(1f, 1f, 1f, 0f);

        Destroy(gameObject);


    }
}