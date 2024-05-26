using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            //detection of the button 
            GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
            if (selectedObject != null)
            {
                Button selectedButton = selectedObject.GetComponent<Button>();
                if (selectedButton != null)
                {
                    selectedButton.onClick.Invoke();
                }
            }
        }

        // navigation with keys arrows or D-PAD
        if (Input.GetAxis("Vertical") != 0)
        {
            NavigateMenu();
        }
    }

    private void NavigateMenu()
    {
        //move the selection btw the buttons
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        if (selectedObject == startButton.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(optionsButton.gameObject);
        }
        else if (selectedObject == optionsButton.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        }
    }

    
    public void OnStartButtonClick()
    {
        
        SceneManager.LoadScene("SCN_NIVEAU1"); 
    }

    public void OnOptionsButtonClick()
    {
        // menu of options
        Debug.Log("Options button clicked");
    }
}
