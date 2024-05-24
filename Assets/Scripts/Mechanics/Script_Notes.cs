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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            timer.remainingTime -= 15f;
            Destroy(gameObject);
        }
    }
}
