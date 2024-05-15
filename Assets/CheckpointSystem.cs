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
        FlagRenderer.color = new Color(134, 255, 0, 255);
        Debug.Log("vefjefie");
    }
}
