using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

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
    [SerializeField] private int trials = 0;// count of trials 

    // QTE GEN
    [SerializeField] private QTEItem[] QTEGen; // Array of QTE items
    private int currentQTEIndex = 0; // current QTE index

    // Define a sequence for QTE appearance order
    [SerializeField] private int[] QTEOrder; // Array to define the order of QTEs

    // Store player inputs for validation
    private List<string> playerSequence = new List<string>();

    // TIMERS
    [SerializeField] private float cooldownBetween = 1.0f; // cooldown result
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
            else
            {
                if (IsSequenceCorrect())
                {
                    StartCoroutine(Results(true)); // Player wins
                }
                else
                {
                    StartCoroutine(Results(false)); // Player loses
                }
            }
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
            if (QTEGen.Length == 0 || QTEPositions.Length == 0 || QTEOrder.Length == 0)
            {
                Debug.LogError("QTEGen, QTEPositions or QTEOrder array is empty. Please populate them in the inspector.");
                return;
            }

            if (currentQTEIndex >= QTEOrder.Length)
            {
                Debug.LogError("QTEOrder array index is out of bounds.");
                return;
            }

            int qteIndex = QTEOrder[currentQTEIndex]; // Get QTE index from the order array
            int positionIndex = currentQTEIndex % QTEPositions.Length; // Cycle through positions

            if (currentQTE != null)
            {
                SetAlpha(currentQTE, 0); // Hide previous QTE GameObject
                Destroy(currentQTE, cooldownBetween); // Destroy after cooldown
            }

            currentQTE = Instantiate(QTEGen[qteIndex].qteObject, QTEPositions[positionIndex].position, Quaternion.identity); // instantiate QTE GameObject at ordered position
            SetAlpha(currentQTE, 1); // Show new QTE GameObject

            waitingForKey = false;
            timer = timerPress;
        }
        else
        {
            if (Input.anyKeyDown) // if key pressed
            {
                if (Input.GetButtonDown(QTEGen[QTEOrder[currentQTEIndex]].key)) // check if the correct key is pressed
                {
                    playerSequence.Add(QTEGen[QTEOrder[currentQTEIndex]].key); // Add key to player sequence
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
            playerSequence.Clear(); // Reset the player's sequence on failure
            currentQTEIndex = 0; // Restart the sequence
        }
        else
        {
            PassBox.GetComponent<Text>().text = "PASS!";
            success++;
            currentQTEIndex++; // Move to the next QTE in the sequence
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

    IEnumerator Results(bool win)
    {
        if (win) // WIN
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

    bool IsSequenceCorrect()
    {
        if (playerSequence.Count != QTEOrder.Length)
        {
            return false;
        }

        for (int i = 0; i < QTEOrder.Length; i++)
        {
            if (playerSequence[i] != QTEGen[QTEOrder[i]].key)
            {
                return false;
            }
        }

        return true;
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





