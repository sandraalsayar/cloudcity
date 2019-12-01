using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerSheep : MonoBehaviour
{
	public bool isNPC;
	public bool firstTime;
	public GameObject player;

    public DialogueManager dialogMan;

	void Start()
	{
		firstTime = true;
        dialogMan = FindObjectOfType<DialogueManager>();
	}

    // Update is called once per frame
	void Update()
	{

		if(isNPC)
		{
            // FIRST ENCOUNTER
			if(Input.GetButtonDown("Interact")){
                if (dialogMan.firstTime)
                {
                    gameObject.GetComponent<TextboxToggle>().TriggerDialogue();
                }
                else
                {
                    dialogMan.DisplayNextSentence();
                }
                //if (firstTime)
                //{
                //    Debug.Log("toggle");
                //    //toggle the text
                //    gameObject.GetComponent<TextboxToggle>().TriggerDialogue();
                //    firstTime = false;
                //}
                //else
                //{
                //    Debug.Log("next");
                //    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                //} 
            }
		}
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("issheep");
            isNPC = true;
        }
        GetComponent<PlayerInteractions>().indication.SetActive(true);
    }

     void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNPC = false;

            //for now if you ever leave trigger area: ends dialogue
            //TODO:make it so player cant move when talking to sheep?
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
        GetComponent<PlayerInteractions>().indication.SetActive(false);

    }
}
