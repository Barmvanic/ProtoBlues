using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Transform _originalParent;
    // Start is called before the first frame update
    void Start()
    {
        _originalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParent(Transform newParent) // to P1 stay on the moving platform 
    {
        // _originalParent = transform.parent;
        transform.parent = newParent;
    }

    public void ResetParent()
    {
        transform.parent = _originalParent;


    }
}
