using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_NotesBlanches : MonoBehaviour
{

    public float speed = 4f;

    bool moveNote;

    [SerializeField] GameObject target;

    void Start()
    {

    }

    
    void Update()
    {
        if (moveNote)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed *Time.deltaTime);
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            moveNote = true; 
            //Destroy(gameObject, 2f); 
        }
    }
}
