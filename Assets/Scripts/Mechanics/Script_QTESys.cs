using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_QTESys : MonoBehaviour
{
    public GameObject DisplayBox;
    public GameObject PassBox;
    public int QTEGen;
    public int waitingForKey;
    public int correctKey;
    public int countingDown;

    public static int successfulQTECount = 0;
    

    private void Update()
    {
        if (waitingForKey == 0)
        {
            QTEGen = Random.Range(1,4);
            countingDown = 1;
            StartCoroutine (CountDown ()); 

            if (QTEGen == 1) 
            {
                waitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[X]"; 
            }
            if (QTEGen == 2)
            {
                waitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[Y]";
            }
            if (QTEGen == 3)
            {
                waitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[B]";
            }
        }

        if(QTEGen == 1)
        {
            if (Input.anyKeyDown) // check if the user press the correct key
            {
                if (Input.GetButtonDown("XKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing(true)); 
                    Debug.Log(" X presse");
                }
                else
                {
                    StartCoroutine(KeyPressing(false));
                    correctKey = 2;
                    StartCoroutine (KeyPressing2 ());
                }
                
            }
        }

        if (QTEGen == 2)
        {
            if (Input.anyKeyDown) // check if the user press the correct key
            {
                if (Input.GetButtonDown("YKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing(true));
                    Debug.Log(" Y presse");
                }
                else
                {
                    StartCoroutine(KeyPressing(false));
                    correctKey = 2;
                    StartCoroutine (KeyPressing2 ());
                }
                
            }
        }

        if (QTEGen == 3)
        {
            if (Input.anyKeyDown) // check if the user press the correct key
            {
                if (Input.GetButtonDown("BKey"))
                {
                    correctKey = 1;
                    StartCoroutine(KeyPressing(true));
                    Debug.Log(" presse");
                }
                else
                {
                    StartCoroutine(KeyPressing(false));
                    correctKey = 2;
                    StartCoroutine (KeyPressing2 ());
                }
                
            }
        }


    }


    IEnumerator KeyPressing(bool success) // when it comes to 0, it's generates a new one 
    {
        QTEGen = 4;
        if (correctKey == 1)
        {
            countingDown = 2;
            PassBox.GetComponent<Text>().text = "PASS!";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;

            if (success)
            {
                successfulQTECount++;
                if (successfulQTECount >= 4)
                {
                    Debug.Log("4 successful QTEs reached. Stopping QTE system.");
                    enabled = false; // Disable this script to stop QTE system
                }
            }

            ExitQTE.successfulQTECount++;
        }
    }
    
    
    IEnumerator KeyPressing2()
    {
        QTEGen = 4;
        if (correctKey == 2)
        {
          countingDown = 2;
          PassBox.GetComponent<Text>().text = "FAIL!";
          yield return new WaitForSeconds(1.5f);
          correctKey = 0;
          PassBox.GetComponent<Text>().text = "";
          DisplayBox.GetComponent<Text>().text = "";
          yield return new WaitForSeconds(1.5f);
          waitingForKey = 0;
          countingDown = 1;
          Debug.Log(" WTF");
        }
        
       
    }
    
    IEnumerator CountDown() // waiting for a couple seconds to reset everything 
    {
        yield return new WaitForSeconds(3.56f); 
        if (countingDown == 1)
        {
            QTEGen = 4;
            countingDown = 2;
            PassBox.GetComponent<Text>().text = "FAIL!";
            yield return new WaitForSeconds(1.5f);
            correctKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            countingDown = 1;
            Debug.Log("failure");
        }
    }
}
