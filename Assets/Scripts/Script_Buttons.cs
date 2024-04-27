using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start_Button()
    {
        SceneManager.LoadScene("SCN_NIVEAU1");
    }
}
