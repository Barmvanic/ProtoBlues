using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_notes : MonoBehaviour
{

    public int notes;
    public TextMeshProUGUI noteText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        noteText.text = ": " + notes.ToString();
    }
}

