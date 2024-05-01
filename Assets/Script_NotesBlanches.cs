using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_NotesBlanches : MonoBehaviour
{

    public float speed = 4f;

    bool moveNote;

    GameObject target;
    GameObject target1;
    GameObject target2;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("toNotes");
        target1 = GameObject.FindGameObjectWithTag("toNotes1");
        target2 = GameObject.FindGameObjectWithTag("toNotes2");
    }

    
    void Update()
    {
        if (moveNote)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed *Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target1.transform.position, speed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target2.transform.position, speed * Time.deltaTime);
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
