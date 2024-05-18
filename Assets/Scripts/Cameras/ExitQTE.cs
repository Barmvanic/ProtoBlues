using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitQTE : MonoBehaviour

{
    public static int successfulQTECount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene scene = SceneManager.GetActiveScene();

        if (collision.CompareTag("Player"))
        {
        if (scene.name == "SCN_NIV3")
            {
                successfulQTECount++; // Incrémente le nombre de QTE réussies dans la scène 3
                if (successfulQTECount >= 4)
                {
                    SceneManager.LoadScene("SCN_NIVEAU1-2"); 
                }
            }
        }
    }
}
