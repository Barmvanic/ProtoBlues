using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Script_Notes : MonoBehaviour
{
    [SerializeField] Inventory_notes inventory_Notes; 
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory_Notes.notes++;

            Destroy(gameObject);
        }
    }
}
