using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_ScoringNotes : MonoBehaviour
{

    public Inventory_notes Notes; 
    [SerializeField] TextMeshProUGUI textScore;

    // Update is called once per frame
    void Update()
    {
        Scoring();
    }

    private void Scoring()
    {
        textScore.text = Notes.notes.ToString();
    }
}
