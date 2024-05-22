using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Script_TimelineIntro : MonoBehaviour
{

   [SerializeField] private float cooldownBetween = 2.5f;

    // UI
    public TMP_Text Intro_Text;


   
    void Start()
    {


        Intro_Text.text = ""; 
        StartCoroutine(Beginning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Beginning()
    {
        yield return new WaitForSeconds(cooldownBetween);
        Intro_Text.text = "";
        yield return new WaitForSeconds(cooldownBetween);
        Intro_Text.text = "";
        yield return new WaitForSeconds(cooldownBetween);
        
        Debug.Log("Beginning of the timeline intro");
    }
}
