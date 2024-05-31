using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Script_Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Timer_Text;

    public float remainingTime;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime < 10)
            {
                Timer_Text.color = Color.red; //under 10 seconds left 
                GameManager.Instance.noteCount = 0; 
            }

        
        }
        else if (remainingTime < 0)
        {
           remainingTime = 0;
           SceneManager.LoadScene("SCN_Timeout");
        } //cinematic
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        Timer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

