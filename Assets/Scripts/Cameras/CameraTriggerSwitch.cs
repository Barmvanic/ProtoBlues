//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;
//using Unity.VisualScripting;

//public class CameraTriggerSwitch : MonoBehaviour
//{
//    public CinemachineVirtualCamera[] virtualCameras;
//    private int defaultPriority = 10;
//    private int activeCameraIndex = 0; // keeps track of wich camera is currently active 

//    private Collider2D _coll;

//    //[SerializeField] public bool yExitDirection;
//    //[SerializeField] public bool xExitDirection;

//    void Start()
//    {
//        _coll = GetComponent<Collider2D>();

//        // Initialize all cameras with default priority
//        foreach (var cam in virtualCameras)
//        {
//            cam.Priority = defaultPriority;
//        }

//        // Set the first camera as the active camera
//        if (virtualCameras.Length > 0)
//        {
//            virtualCameras[0].Priority = defaultPriority + 1;
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {

//            if (virtualCameras[0].Priority == defaultPriority + 1)
//                SwitchCamera();


//        }
//    }

//    //private void OnTriggerExit2D(Collider2D other)
//    //{
//    //    if (other.CompareTag("Player"))
//    //    {
//    //        Vector2 exitDirection = (other.transform.position - _coll.bounds.center).normalized;

//    //        if (yExitDirection == false) // If horizontal
//    //        {
//    //            if (xExitDirection == false && exitDirection.x < 0) // right
//    //            {
//    //                SwitchCamera();
//    //            }
//    //            else if (xExitDirection == true && exitDirection.x > 0) // left
//    //            {
//    //                SwitchCamera();
//    //            }
//    //        }

//    //        if (yExitDirection == true) // If vertical
//    //        {
//    //            if (xExitDirection == false && exitDirection.y > 0) // up
//    //            {
//    //                SwitchCamera();
//    //            }
//    //            else if (xExitDirection == true && exitDirection.y < 0) //down
//    //            {
//    //                SwitchCamera();
//    //            }
//    //        }
//    //    }
//    //}

//    private void SwitchCamera()
//    {
//        // Lower the priority of the currently active camera
//        virtualCameras[activeCameraIndex].Priority = defaultPriority;

//        // Calculate the next camera index
//        activeCameraIndex = (activeCameraIndex + 1) % virtualCameras.Length;

//        // Increase the priority of the new active camera
//        virtualCameras[activeCameraIndex].Priority = defaultPriority + 1;
//    }

//}
