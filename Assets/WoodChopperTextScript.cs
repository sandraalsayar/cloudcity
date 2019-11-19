using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChopperTextScript : MonoBehaviour
{

	public bool isNPC;
	public bool firstTime;
	public GameObject player;
	public bool tutorialDone; // signifies that first encounter dialogue finished

    // Start is called before the first frame update
	void Start()
	{
		isNPC = false;
		firstTime = true;
		tutorialDone = false;
	}

    // Update is called once per frame
	void Update()
	{
		if(isNPC)
		{
			
			if(Input.GetButtonDown("Interact")){

				if (firstTime)
				{
					Debug.Log("toggle");
					gameObject.GetComponent<TextboxToggle>().TriggerDialogue();
					firstTime = false;
				}
				else
				{
					Debug.Log("next");
					FindObjectOfType<DialogueManager>().DisplayNextSentence();
				} 
			}
		}
	}
	// how can i make it so that when dialogue ends in WoodChopperTextScript.cs the AI sheep will start walking away?

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
            Debug.Log("issheep");
			isNPC = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			isNPC = false;
			FindObjectOfType<DialogueManager>().EndDialogue();
		}
	}
}
