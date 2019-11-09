﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnd : MonoBehaviour
{
    public bool well;
    public GameObject player;
    StarCollector starCollector;

    public bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        well = false;
        firstTime = true;
        starCollector = player.GetComponent<StarCollector>();
    }

    //// Update is called once per frame
    void Update()
    {
        //will only go through if you complete the game
        if(well)
        {
            if (Input.GetButtonDown("Interact"))
            {
                starCollector.endgame = true;
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
        }


    }

    void OnTriggerEnter(Collider c){
        if (c.CompareTag("Player")
            && starCollector.starCount==7)
        {
            well = true;
        }
    }
    void OnTriggerExit(Collider c)
    {
        //starcount hardcoded to be 2 for now
        if (c.CompareTag("Player"))
        {
            well = false;
        }
    }

}
