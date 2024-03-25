using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Light_flicker : MonoBehaviour
{
    // LIGHT
    public Light2D myLight;
    [SerializeField] private float intens = 8;

    // TIMER
    [SerializeField] float StartTime;
    [SerializeField] float CurrentTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // GET LIGHT
        myLight = GetComponent<Light2D>();

        // START TIMER TIME
        StartTime = CurrentTime;
    }

    // Update is called once per frame
    void Update()
    {
        // IF TIMER WENT OUT OF TIME
        if (CurrentTime <= 0f)
        {
            // RESTART TIMER
            CurrentTime = StartTime;
        }

        Timer();
    }


    void Timer()
    {
        // COUNT DOWN TIMER
        CurrentTime -= 1 * Time.deltaTime;

        if (CurrentTime <= StartTime/2)
        {
            // LIGHT OFF
            myLight.intensity = 0;
        }
        else
        {
            // LIGHT ON
            myLight.intensity = intens;
        }
    }
}
