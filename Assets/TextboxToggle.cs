using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script stores the dialogue info on the NPC
public class TextboxToggle : MonoBehaviour
{
    //access the text for this NPC
    public Dialogue dialogue;
    //start the dialogue
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
