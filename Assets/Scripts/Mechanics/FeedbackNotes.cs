//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FeedbackNotes : MonoBehaviour
//{
//    // COLLIDERS
//    [SerializeField] Collider2D GoodNoteCollider;
//    [SerializeField] Collider2D BadNoteCollider;

//    //COLOR 
//    [SerializeField] Color GreenNotes;
//    [SerializeField] Color RedNotes;

//    //CHANGE COLOR
//    [SerializeField] SpriteRenderer NotesBlanches;
//    [SerializeField] SpriteRenderer CrochesRouges; 
   
//    public void FeedbackGreen()
//    {
//        GoodNoteCollider.enabled = false;
//        NotesBlanches.color = GreenNotes;
//        Debug.Log("Green notes");
//    }

//    public void FeedbackRed()
//    {
//        CrochesRouges = RedNotes;
//        Debug.Log("Red notes");
//    }
//}
