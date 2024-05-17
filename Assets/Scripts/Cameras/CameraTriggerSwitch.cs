using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class CameraTriggerSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    private int defaultPriority = 10;
    private int activeCameraIndex = 0; // keeps track of wich camera is currently active 

    void Start()
    {
        // Initialize all cameras with default priority
        foreach (var cam in virtualCameras)
        {
            cam.Priority = defaultPriority;
        }

        // Set the first camera as the active camera
        if (virtualCameras.Length > 0)
        {
            virtualCameras[0].Priority = defaultPriority + 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // Lower the priority of the currently active camera
        virtualCameras[activeCameraIndex].Priority = defaultPriority;

        // Calculate the next camera index
        activeCameraIndex = (activeCameraIndex + 1) % virtualCameras.Length;

        // Increase the priority of the new active camera
        virtualCameras[activeCameraIndex].Priority = defaultPriority + 1;
    }

}
