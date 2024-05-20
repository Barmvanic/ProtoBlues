using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QTESystem_Notes : MonoBehaviour
{
    // REQUIREMENTS
    public static GameManager instance; // for notecount
    [SerializeField] private int notereset = 0;
    [SerializeField] private int requiredSucess = 4; // number of successful QTE for passing lvl
    [SerializeField] private int success = 0; // count of success
    private int trials = 0;

    // QTE GEN
    //[SerializeField] private char[] QTEGen = new char[3]; // QTE choices
    private int i; // random QTE

    // TIMERS
    [SerializeField] private float cooldownBetween = 1.5f; // cooldown result
    [SerializeField] private float timerPress = 3f; // time you have to press the QTE
    private bool waitingForKey;
    private float timer;
    private bool started;

    // UI
    public GameObject DisplayBox;
    public GameObject PassBox;

    // QTE UI IMAGE
    public Image QTEImage; // UI Image component for displaying QTE
    public Sprite[] QTESprites; // sprites for QTE keys (X, Y, B)
    public List<Vector3> QTEPositions; // positions for QTE appearance

    // Start is called before the first frame update
    void Start()
    {
        //QTEGen[0] = 'X';
        //QTEGen[1] = 'Y';
        //QTEGen[2] = 'B';

        waitingForKey = true;
        timer = timerPress; // reset timer

        started = false;
        PassBox.GetComponent<Text>().text = "";
        //DisplayBox.GetComponent<Text>().text = "";
        StartCoroutine(Starting());
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (success < requiredSucess && trials < GameManager.Instance.noteCount) // if not win yet and not lose yet
            {
                QTEPlay();
            }
            else StartCoroutine(Results());
        }

        Timer(); // start timer for pressing
    }

    void QTEPlay()
    {
        if (waitingForKey) // gen key
        {
            i = Random.Range(0, 3); // generate random number for QTEGen
            QTEImage.sprite = QTESprites[i]; // update the QTE image based on the key
            int posIndex = Random.Range(0, QTEPositions.Count); // choose a random position index
            QTEImage.rectTransform.localPosition = QTEPositions[posIndex]; // set the position
            waitingForKey = false;
            timer = timerPress;
        }
        else
        {
            if (Input.anyKeyDown) // if key pressed
            {
                if ((i == 0 && Input.GetButtonDown("XKey")) || (i == 1 && Input.GetButtonDown("YKey")) || (i == 2 && Input.GetButtonDown("BKey")))
                {
                    StartCoroutine(Next(true)); // if good key
                }
                else StartCoroutine(Next(false)); // bad key
            }
            else if (timer <= 0)
            {
                StartCoroutine(Next(false)); // no more time
            }
        }
    }

    void Timer()
    {
        if (!waitingForKey && timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    IEnumerator Starting()
    {
        yield return new WaitForSeconds(cooldownBetween);
        PassBox.GetComponent<Text>().text = "You're ready? Let's go ~";
        yield return new WaitForSeconds(cooldownBetween);
        PassBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(cooldownBetween);
        started = true;
        Debug.Log("Starting"); 
    }

    IEnumerator Next(bool pass)
    {
        timer = cooldownBetween * 2; // just to be sure timer does not go down to 0 when displaying result

        // Display result
        if (!pass)
        {
            PassBox.GetComponent<Text>().text = "FAIL!";
        }
        else
        {
            PassBox.GetComponent<Text>().text = "PASS!";
            success++;
        }

        // Erase result
        yield return new WaitForSeconds(cooldownBetween);
        PassBox.GetComponent<Text>().text = "";
        QTEImage.sprite = null; // clear the QTE image

        trials++;

        // Next
        float wait = cooldownBetween * 2 / 3;
        yield return new WaitForSeconds(wait);
        waitingForKey = true;
        timer = timerPress; //reset timer

        Debug.Log("Next");
    }

    IEnumerator Results()
    {
        if (success >= requiredSucess) // WIN
        {
            PassBox.GetComponent<Text>().text = "Not bad, Rookie.";
            yield return new WaitForSeconds(cooldownBetween);
            SceneManager.LoadScene("SCN_NIVEAU1-2");
            Debug.Log("WIN");
        }
        else // FAIL
        {
            PassBox.GetComponent<Text>().text = "You'll have to do better, Andy ~";
            yield return new WaitForSeconds(cooldownBetween);
            GameManager.Instance.noteCount = notereset;
            SceneManager.LoadScene("SCN_NIVEAU1");
            Debug.Log("LOSE");
        }
    }
}



