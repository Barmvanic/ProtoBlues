using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseapearingPlatform : MonoBehaviour
{

    public float timeToTogglePlatform = 2; // how many time the platform gonna disappear
    public float currentTime = 0;
    public bool enabled = true; 

    // Start is called before the first frame update
    void Start()
    {
        enabled = true; //able to function with 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; 
        if (currentTime >= timeToTogglePlatform)
        {
            currentTime = 0;
            TogglePlatform(); 
        }
    }

    void TogglePlatform()
    {
        enabled = !enabled; //false
        foreach(Transform child in gameObject.transform) //each child object of a the parent 
        {
            if (child.tag != "Player") // permits that the player don't disappear 
            {
                child.gameObject.SetActive(enabled);
            }
        }
    }
}
