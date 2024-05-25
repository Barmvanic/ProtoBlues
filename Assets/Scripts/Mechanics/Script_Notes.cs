using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Notes : MonoBehaviour
{
    [SerializeField] Script_Timer timer;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            timer.remainingTime -= 15f;
            Destroy(gameObject);
        }
    }
}
