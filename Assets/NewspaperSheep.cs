using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperSheep : MonoBehaviour
{
    public bool isNPC;
    public bool firstTime;
    public bool quest; //track whether the player is doing quest or not
    public bool complete;

    public const int newspaperCount = 22; //TODO: change this to be wat max we want
    public GameObject player;
    //public GameObject newsStar;
    public GameObject questComplete;
    public GameObject questIncomplete;
    StarCollector starCollector;
    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        quest = false;
        starCollector = player.GetComponent<StarCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        //notify in quest
        //TODO: nofity when quest is over, remove HUD of newspaper
        if(quest){
            starCollector.inQuest = true;
        }
        if(isNPC)
        {
            if(Input.GetButtonDown("Interact") && !quest){
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
                } 
            }
            //currently in quest
            // quest should never be reset!!
            // dont interact with sheep again (for now)
            else if(Input.GetButtonDown("Interact") && quest)
            {
                Debug.Log("in quest");
                //complete
                if(newspaperCount == starCollector.newsDelivered){
                    Debug.Log("you get a star!");
                    complete = true;
                    if (firstTime)
                    {
                        //trigger completion dialogue
                        questComplete.GetComponent<TextboxToggle>().TriggerDialogue();
                        firstTime = false;
                    }
                    else
                    {
                        Debug.Log("next");
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                        //EndDialogue() will handle giving star
                    } 
                } 
                // else { //else not complete, have sheep say some text, finish delivering
                //     complete = false;
                //     questComplete.GetComponent<TextboxToggle>().TriggerDialogue();
                // }
                

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
    }
}
