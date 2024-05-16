using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;

public class CameraControlTrigger : MonoBehaviour
{
    public CustomInspectorObjects customInspectorObjects;

    private Collider2D _coll;

    private void Start()
    {
        _coll = GetComponent<Collider2D>();
        customInspectorObjects = new CustomInspectorObjects(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("triggered");
            if (customInspectorObjects.panCameraOnContact)
            {
                // pan the camera
                CameraManager.instance.PanCameraOnContact(customInspectorObjects.panDistance, customInspectorObjects.panTime,customInspectorObjects.panDirection, false);
                Debug.Log("pan cam enter");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("exited");

            Vector2 exitDirection = (collision.transform.position - _coll.bounds.center).normalized;

            Debug.Log(exitDirection);

            if (customInspectorObjects.swapCameras && customInspectorObjects.cameraOnLeft != null && customInspectorObjects.cameraOnRight != null)
            {
                //swap cameras 
                CameraManager.instance.SwapCamera(customInspectorObjects.cameraOnLeft, customInspectorObjects.cameraOnRight, exitDirection);
                Debug.Log("swap cam");
            }
            if (customInspectorObjects.panCameraOnContact)
            {
                // pan the camera
                CameraManager.instance.PanCameraOnContact(customInspectorObjects.panDistance, customInspectorObjects.panTime, customInspectorObjects.panDirection, true);
                Debug.Log("pan cam exit");
            }
        }
    }
}


[System.Serializable]
public class CustomInspectorObjects
{
    public bool swapCameras = false;
    public bool panCameraOnContact = false;

    [HideInInspector] public CinemachineVirtualCamera cameraOnLeft;
    [HideInInspector] public CinemachineVirtualCamera cameraOnRight;

    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 3f;
    [HideInInspector] public float panTime = 0.35f;
}

public enum PanDirection // select which direction the camera will pan in the inspector 
{
    Up,
    Down,
    Left,
    Right,
}


//[CustomEditor(typeof(CameraControlTrigger))]
//public class MyScriptEditor : Editor
//{
//    CameraControlTrigger cameraControlTrigger;

//    private void OnEnable()
//    {
//        cameraControlTrigger = (CameraControlTrigger)target;
//    }

//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        if (cameraControlTrigger.customInspectorObjects.swapCameras)
//        {
//            cameraControlTrigger.customInspectorObjects.cameraOnLeft = EditorGUILayout.ObjectField("Camera on Left", cameraControlTrigger.customInspectorObjects.cameraOnLeft,
//                typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;

//            cameraControlTrigger.customInspectorObjects.cameraOnRight = EditorGUILayout.ObjectField("Camera on Right", cameraControlTrigger.customInspectorObjects.cameraOnRight,
//                typeof(CinemachineVirtualCamera), true) as CinemachineVirtualCamera;
//        }

//        if (cameraControlTrigger.customInspectorObjects.panCameraOnContact)
//        {
//            cameraControlTrigger.customInspectorObjects.panDirection = (PanDirection)EditorGUILayout.EnumPopup("Camera Pan Direction",
//                cameraControlTrigger.customInspectorObjects.panDirection);

//            cameraControlTrigger.customInspectorObjects.panDistance = EditorGUILayout.FloatField("Pan Distance", cameraControlTrigger.customInspectorObjects.panDistance);
//            cameraControlTrigger.customInspectorObjects.panTime = EditorGUILayout.FloatField("Pan Time", cameraControlTrigger.customInspectorObjects.panTime);

//        }

//        if (GUI.changed) // don't reset the inspector 
//        {
//            EditorUtility.SetDirty(cameraControlTrigger);
//        }
//    }
//}

