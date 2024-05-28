using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Button startButton;
    public Button optionsButton;
    public Button backButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        //optionsButton.onClick.AddListener(OpenOptions);
        //backButton.onClick.AddListener(CloseOptions);

        // Initial menu setup
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        // Select the first button for controller support
        startButton.Select();
    }

    void Update()
    {
        // Controller navigation (Xbox controller) and keyboard support
        if (Input.GetButtonDown("Submit"))
        {
            if (mainMenu.activeSelf)
            {
                if (startButton.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
                {
                    StartGame();
                }
            //    else if (optionsButton.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            //    {
            //        OpenOptions();
            //        Debug.Log("Options menu open."); 
            //    }
            //}
            //else if (optionsMenu.activeSelf)
            //{
            //    if (backButton.gameObject == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject)
            //    {
            //        CloseOptions();
            //        Debug.Log("Options menu open.");
            //    }
            }
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("SCN_IntroCinematic");
    }

    //void OpenOptions()
    //{
    //    mainMenu.SetActive(false);
    //    optionsMenu.SetActive(true);
    //    backButton.Select();
    //}

    //void CloseOptions()
    //{
    //    optionsMenu.SetActive(false);
    //    mainMenu.SetActive(true);
    //    startButton.Select();
    //}
}
