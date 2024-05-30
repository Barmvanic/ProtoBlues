using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    //public void Start_Button()
    //{
    //    SceneManager.LoadScene("SCN_IntroCinematic");
    //}

    //public void Options_Button()
    //{
    //    SceneManager.LoadScene("SCN_OPTIONS");
    //}

    public void Change_Scene1()
    {
        SceneManager.LoadScene("SCN_Main_Menu");
    }

    public void After_Reward()
    {
        SceneManager.LoadScene("SCN_NIVEAU1-2");
    }

    public void Time_Out()
    {
        SceneManager.LoadScene("SCN_NIVEAU1");
    }

    public void Final_Scene()
    {
        SceneManager.LoadScene("SCN_DEVIL");
    }

    public void Tuto_Scene()
    {
        SceneManager.LoadScene("SCN_NIVEAU1");
    }
    public void Credits_Scene()
    {
        SceneManager.LoadScene("SCN_CREDITS");
    }

    public void Back_MM()
    {
        SceneManager.LoadScene("SCN_Main_Menu");
    }

}
