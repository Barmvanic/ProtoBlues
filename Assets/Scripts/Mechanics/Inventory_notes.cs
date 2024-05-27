using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_notes : MonoBehaviour
{

    [SerializeField] GameManager gm;
    public TextMeshProUGUI noteText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        noteText.text = ": " + GameManager.Instance.noteCount.ToString();
    }
}

