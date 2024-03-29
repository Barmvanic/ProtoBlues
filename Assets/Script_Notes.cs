using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Script_Notes : MonoBehaviour
{
    private P1_player; 
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("P1").GetComponent<P1>(); ; 
        if(_player == null)
        {
            Debug.LogError("Player is null"); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag = "Player")
        {
            _player.AddCoins(1);

            Destroy(gameObject); 
        }
    }
}
