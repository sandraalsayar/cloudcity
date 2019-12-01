using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChopperTextScript : MonoBehaviour
{

	public bool isNPC;
	public bool firstTime;
	public GameObject player;
	public bool tutorialDone; // signifies that first encounter dialogue finished
	public int convocounter;

    // Start is called before the first frame update
	void Start()
	{
		isNPC = false;
		firstTime = true;
		tutorialDone = false;
		convocounter = 0; // used to make sheep walk away after speaking 4 lines
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
					convocounter++;
				}
				else
				{
					Debug.Log("next");
					FindObjectOfType<DialogueManager>().DisplayNextSentence();
					convocounter++;
				} 
				
			}

			if (convocounter == 5) {
				tutorialDone = true;
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
            GetComponent<PlayerInteractions>().indication.SetActive(true);
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			isNPC = false;
			FindObjectOfType<DialogueManager>().EndDialogue();
            GetComponent<PlayerInteractions>().indication.SetActive(false);
		}

	}
}
