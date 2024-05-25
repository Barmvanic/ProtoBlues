using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_NotesBlanches : MonoBehaviour
{

    public float speed = 4f;
    [SerializeField] Script_Timer timer;

    void Start()
    {

    }

    
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer.remainingTime += 10f;
            Debug.Log("+10");
            // gameObject.GetComponent<Collider2D>().enabled = false;
            // moveNote = true;
            Destroy(gameObject); 

            // Incrémente la variable noteCount dans le script ChangeSceneQTE
            GameManager.Instance.noteCount++;

            Debug.Log("Note collected");

     
        }
    }
 }
