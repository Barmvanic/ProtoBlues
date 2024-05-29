using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_NotesBlanches : MonoBehaviour
{


    [SerializeField] Script_Timer timer;
    public Inventory_notes nc; //notecount

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
            gameObject.GetComponent<Collider2D>().enabled = false;
            // Incrémente la variable noteCount dans le script ChangeSceneQTE
            GameManager.Instance.noteCount++;
            Destroy(gameObject);
            Debug.Log("Note collected");


        }
    }
}

