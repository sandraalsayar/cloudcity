using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewspaperSheep : MonoBehaviour
{
    public bool isNPC;
    public bool firstTime;
    public bool quest; //track whether the player is doing quest or not
    public bool complete;
    public bool sheepTalked;

    public const int newspaperCount = 19; //TODO: change this to be wat max we want
    public GameObject player;
    //public GameObject newsStar;
    public GameObject questCompleteText;
    public GameObject questInProgressText;
    public GameObject questFailedText;
    StarCollector starCollector;
    // Start is called before the first frame update

    //public Text indication;

    void Start()
    {
        firstTime = true;
        quest = false;
        starCollector = player.GetComponent<StarCollector>();
    }

    // Update is called once per frame
    void Update()
    {

        if(quest){
            starCollector.inQuest = true;
        }

        if(isNPC)
        {
            // FIRST ENCOUNTER
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
            // IN QUEST
            // quest should never be reset!! dont interact with sheep again (for now)
            else if(Input.GetButtonDown("Interact") && quest)
            {
                Debug.Log("in quest");
                // SUCCESS- ALL DELIEVRED
                if(newspaperCount == starCollector.newsDelivered){
                    Debug.Log("you get a star!");
                    complete = true;
                    starCollector.inQuest = false;
                    if (firstTime)
                    {
                        //trigger completion dialogue
                        questCompleteText.GetComponent<TextboxToggle>().TriggerDialogue();
                        firstTime = false;
                    }
                    else
                    {
                        Debug.Log("next");
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    } 

                    // IN-PROGRESS - CONTINUE DELIVERING
                } else if(starCollector.newsDelivered < 19 && starCollector.remainingNews != 0)  { 
                    Debug.Log("go finish delivering");
                    complete = false;

                    if (firstTime)
                    {
                        Debug.Log("toggle");
                        //toggle the text
                        questInProgressText.GetComponent<TextboxToggle>().TriggerDialogue();
                        firstTime = false;
                    }
                    else
                    {
                        Debug.Log("next");
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    } 
                    // FAIL - DO IT AGAIN
                } else if(starCollector.newsDelivered < 19 && starCollector.remainingNews <= 0)  { 
                    Debug.Log("start again");
                    complete = false;

                    if (firstTime)
                    {
                        Debug.Log("toggle");
                        //toggle the text
                        questFailedText.GetComponent<TextboxToggle>().TriggerDialogue();
                        firstTime = false;
                    }
                    else
                    {
                        Debug.Log("next");
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    } 
                    starCollector.remainingNews = 3;

                }

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
        //enable indication, means it'll only show if you're suuuuper close, maybe change to a different area check?
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
