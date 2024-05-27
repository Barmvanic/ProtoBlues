using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    [SerializeField] Collider2D CheckpointCollider;
    [SerializeField] SpriteRenderer FlagRenderer;
    [SerializeField] Color GreenFlag; 

    public void CheckpointFeedback()
    {
        CheckpointCollider.enabled = false;
        FlagRenderer.color = new Color(0.1f, 1, 0, 0);
        Debug.Log("color chekcpoint");
    }


}
