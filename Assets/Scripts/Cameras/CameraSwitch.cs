using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    private int defaultPriority = 10;
    // private int activeCameraIndex = 0; // keeps track of wich camera is currently active 

    [SerializeField] int camerain;
    [SerializeField] int cameraout;


    private Collider2D _coll;

    [SerializeField] public bool yExitDirection;
    [SerializeField] public bool xExitDirection;

    void Start()
    {
        _coll = GetComponent<Collider2D>();


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bool switchyes = false;
            for (int i = 0; i < virtualCameras.Length; i++)
            {
                if (i != camerain)
                {
                    if (virtualCameras[i].Priority >= virtualCameras[camerain].Priority)
                        switchyes = true;
                }
            }
            if (switchyes)
            SwitchCamera();
            Debug.Log("Player enter the trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 exitDirection = (other.transform.position - _coll.bounds.center).normalized;

            if (yExitDirection == false) // If horizontal
            {
                if (xExitDirection == false && exitDirection.x < 0) // right
                {
                    SwitchCamera();
                }
                else if (xExitDirection == true && exitDirection.x > 0) // left
                {
                    SwitchCamera();
                }
            }

            if (yExitDirection == true) // If vertical
            {
                if (xExitDirection == false && exitDirection.y > 0) // up
                {
                    SwitchCamera();
                }
                else if (xExitDirection == true && exitDirection.y < 0) //down
                {
                    SwitchCamera();
                }
            }
        }
    }

    private void SwitchCamera()
    {

        int switchto;
        if (virtualCameras[camerain].Priority > virtualCameras[cameraout].Priority)
        {
            switchto = cameraout;
        }
        else switchto = camerain;

        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = 10;
        }
        virtualCameras[switchto].Priority = 20;


    }

}
