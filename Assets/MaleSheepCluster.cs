using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleSheepCluster : MonoBehaviour
{
	public bool isNPC;
	public bool firstTime;
	public GameObject player;

	void Start()
	{
		firstTime = true;
	}

    // Update is called once per frame
	void Update()
	{
		if(isNPC)
		{
            // FIRST ENCOUNTER
			if(Input.GetButtonDown("Interact")){
				if (firstTime)
				{
					Debug.Log("toggle");
                    //toggle the text
					gameObject.GetComponent<TextboxToggle>().TriggerDialogue();
					firstTime = false;
				}
				else
				{
					Debug.Log("next");
					FindObjectOfType<DialogueManager>().DisplayNextSentence();
					firstTime = true;
				} 
			}
		}
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("issheep");
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
