//using System.Collections;
//using System.Collections.Generic;
//using System.Transactions;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;


//public class Script_QTE_Kyo : MonoBehaviour
//{
//    // REQUIREMENTS
//    public static GameManager instance; // for notecount
//    [SerializeField] private int notereset = 0;
//    [SerializeField] private int requiredSucess = 4; // number of successful QTE for passing lvl
//    [SerializeField] private int success = 0; // count of success
//    private int trials = 0;

//    // QTE GEN
//    [SerializeField] private char[] QTEGen = new char[3]; // QTE choices
//    private int i; // random QTE

//    // TIMERS
//    [SerializeField] private float cooldownBetween = 1.5f; // cooldown result
//    [SerializeField] private float timerPress = 3f; // time you have to press the QTE
//    private bool waitingForKey;
//    private float timer;
//    private bool started;

//    // UI
//    public GameObject DisplayBox;
//    public GameObject PassBox;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // QTE gen
//        QTEGen[0] = 'X';
//        QTEGen[1] = 'Y';
//        QTEGen[2] = 'B';

//        waitingForKey = true;
//        timer = timerPress; // reset timer

//        started = false;
//        PassBox.GetComponent<Text>().text = "";
//        DisplayBox.GetComponent<Text>().text = "";
//        StartCoroutine(Starting());
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (started)
//        {
//            if (success < requiredSucess && trials < GameManager.Instance.noteCount) // if not win yet and not loose yet
//            {
//                QTEPlay();
//            }
//            else StartCoroutine(Results());
//        }

//        Timer(); // start timer for pressing

//    }

//    void QTEPlay()
//    {
//        if (waitingForKey) // gen key
//        {
//            i = Random.Range(0, 3); // generate random number for QTEGen
//            DisplayBox.GetComponent<Text>().text = "[" + QTEGen[i] + "]"; // display
//            waitingForKey = false;
//            timer = timerPress;
//        }
//        else
//        {

//            if (Input.anyKeyDown) // if key pressed
//            {
//                if ((i == 0 && (Input.GetButtonDown("XKey"))) || (i == 1 && (Input.GetButtonDown("YKey"))) || (i == 2 && (Input.GetButtonDown("BKey"))))
//                {
//                    StartCoroutine(Next(true)); // if good key
//                }
//                else StartCoroutine(Next(false)); // bad key
//            }
//            else if (timer <= 0)
//            {
//                StartCoroutine(Next(false)); // no more time
//            }

//        }

//    }

//    // can't do it with coroutine, because we have to have the control over time
//    void Timer()
//    {
//        if (!waitingForKey && timer > 0)
//        {
//            timer -= 1 * Time.deltaTime;
//        }
//    }

//    IEnumerator Starting()
//    {
//        yield return new WaitForSeconds(cooldownBetween);
//        PassBox.GetComponent<Text>().text = "You're ready? Let's go ~";
//        yield return new WaitForSeconds(cooldownBetween);
//        PassBox.GetComponent<Text>().text = "";
//        yield return new WaitForSeconds(cooldownBetween);
//        started = true;
//    }

//    IEnumerator Next(bool pass)
//    {
//        timer = cooldownBetween * 2; // just to be sure timer does not go down to 0 when displaying result

//        // Display result
//        if (!pass)
//        {
//            PassBox.GetComponent<Text>().text = "FAIL!";
//        }
//        else
//        {
//            PassBox.GetComponent<Text>().text = "PASS!";
//            success++;
//        }

//        // Erase result
//        yield return new WaitForSeconds(cooldownBetween);
//        PassBox.GetComponent<Text>().text = "";
//        DisplayBox.GetComponent<Text>().text = "";

//        trials++;

//        // Next
//        float wait = cooldownBetween * 2 / 3;
//        yield return new WaitForSeconds(wait);
//        waitingForKey = true;
//        timer = timerPress; //reset timer
//    }

//    IEnumerator Results()
//    {
//        if (success >= requiredSucess) // WIN
//        {
//            PassBox.GetComponent<Text>().text = "Not bad, Rookie.";
//            yield return new WaitForSeconds(cooldownBetween);
//            DisplayBox.GetComponent<Text>().text = "";

//            // idk what ya wanna do when ya win, gurl
//            SceneManager.LoadScene("SCN_NIVEAU1-2");
//        }
//        else // FAIL
//        {
//            PassBox.GetComponent<Text>().text = "You'll have to do better, Andy ~";
//            yield return new WaitForSeconds(cooldownBetween);
//            DisplayBox.GetComponent<Text>().text = "";

//            // count note reset
//            GameManager.Instance.noteCount = notereset;

//            // return to main menu?
//            SceneManager.LoadScene("SCN_NIVEAU1");
//        }
//    }
//}
