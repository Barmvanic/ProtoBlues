using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QTEItem // permits to set up the key with the image 
{
    public GameObject qteObject; // the GameObject representing the QTE (with the image)
    public string key; // the key associated with this QTE (like"BKey")
}

public class QTESystem_Notes : MonoBehaviour
{
    public static GameManager instance; // for notecount
    [SerializeField] private int notereset = 0;
    [SerializeField] private int requiredSuccess = 4; // number of successful QTE for passing lvl
    [SerializeField] private int success = 0; // count of success
    private int trials = 0;

    // QTE GEN
    [SerializeField] private QTEItem[] QTEGen; // Array of QTE items
    private int i; // random QTE

    // TIMERS
    [SerializeField] private float cooldownBetween = 2.5f; // cooldown result
    [SerializeField] private float timerPress = 3f; // time you have to press the QTE
    private bool waitingForKey;
    private float timer;
    private bool started;

    // UI
    public GameObject PassBox;
    public TextMeshProUGUI trialsText; 

    // QTE POSITIONS
    public Transform[] QTEPositions; // positions for QTE appearance

    private GameObject currentQTE;

    void Start()
    {
        UpdateTrialsUI();
        waitingForKey = true;
        timer = timerPress; // reset timer

        started = false;
        PassBox.GetComponent<Text>().text = "";
        StartCoroutine(Starting());
    }

    void Update()
    {
        if (started)
        {
            if (success < requiredSuccess && trials < GameManager.Instance.noteCount) // if not win yet and not lose yet
            {
                QTEPlay();
            }
            else StartCoroutine(Results());
        }

        Timer(); // start timer for pressing
    }


    void UpdateTrialsUI() // update the number of trials 
    {
        if (trialsText != null)
        {
            trialsText.text = "Trials :" + trials.ToString() + "/4";
        }    
        else
        {
            Debug.LogError("Trials Text UI component is not assigned in the inspector.");
        }
            
    }
    void QTEPlay()
    {
        if (waitingForKey) // gen key
        {

            if (QTEGen.Length == 0 || QTEPositions.Length == 0)
            {
                Debug.LogError("QTEGen or QTEPositions array is empty. Please populate them in the inspector.");
                return;
            }
            i = Random.Range(0, QTEGen.Length); // generate random number for QTEGen
            int positionIndex = Random.Range(0, QTEPositions.Length); // get a random position 


            if (currentQTE != null)
            {
                SetAlpha(currentQTE, 0); // Hide previous QTE GameObject
                Destroy(currentQTE, cooldownBetween); // Destroy after cooldown
            }

            currentQTE = Instantiate(QTEGen[i].qteObject, QTEPositions[positionIndex].position, Quaternion.identity); // instantiate QTE GameObject at random position
            SetAlpha(currentQTE, 1); // Show new QTE GameObject

            waitingForKey = false;
            timer = timerPress;
        }
        else
        {
            if (Input.anyKeyDown) // if key pressed
            {
                if (Input.GetButtonDown(QTEGen[i].key)) // check if the correct key is pressed
                {
                    StartCoroutine(Next(true)); // if good key
                }
                else
                {
                    StartCoroutine(Next(false)); // bad key
                }
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
        PassBox.GetComponent<Text>().text = "Are you ready?";
        yield return new WaitForSeconds(cooldownBetween);
        PassBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(cooldownBetween);
        started = true;
        Debug.Log("Starting");
    }

    IEnumerator Next(bool pass)
    {
        timer = cooldownBetween * 2; // just to be sure timer does not go down to 0 when displaying result

        
        UpdateTrialsUI(); // update the number of trials

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
        if (currentQTE != null)
        {
            SetAlpha(currentQTE, 0); // hide current QTE GameObject
            Destroy(currentQTE, cooldownBetween); // Destroy after cooldown
        }

        trials++;

        // Next
        float wait = cooldownBetween * 2 / 3;
        yield return new WaitForSeconds(wait);
        waitingForKey = true;
        timer = timerPress; // reset timer

        Debug.Log("Next");
    }

    IEnumerator Results()
    {
        if (success >= requiredSuccess) // WIN
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

    void SetAlpha(GameObject obj, float alpha) // call ALPHA 
    {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            Color color = renderer.color;
            color.a = alpha;
            renderer.color = color;
        }
    }
}





