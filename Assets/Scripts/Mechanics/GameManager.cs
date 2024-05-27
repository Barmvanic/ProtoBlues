using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance;

    // Private constructor to prevent instantiation
    private GameManager() { }

    // Variables to manage state
    public int noteCount = 0;


    void Start()
    {
        // Set the screen resolution
        Screen.SetResolution(1920, 1080, true);
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

}

