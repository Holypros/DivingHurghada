using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
  
    public void Start()
    {
        StartCoroutine(dialoguetrigger());
    }

    IEnumerator dialoguetrigger()
    {
        
        yield return new WaitForSeconds(2);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
