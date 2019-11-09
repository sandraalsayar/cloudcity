using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//needs to be on whatever is going to be controlling going btwn next dialogue 
public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    //gameobjects that will have dialogue
    public GameObject player;
    StarCollector starCollector;
    public GameObject NewsSheep;
    NewspaperSheep sheep;
    public GameObject newsStar;


    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        sheep = NewsSheep.GetComponent<NewspaperSheep>();
        starCollector = player.GetComponent<StarCollector>();
    }

    public void StartDialogue (Dialogue d)
    {
        animator.SetBool("isOpen", true);
        Debug.Log("start convo for" + d.name);
        nameText.text = d.name;
        //clear previous
        sentences.Clear();
        //load dialogue
        foreach(string sent in d.sentences)
        {
            sentences.Enqueue(sent);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        Debug.Log("end ofconvo");
        animator.SetBool("isOpen", false);
        if(starCollector.endgame){
            Debug.Log("endScene");
            SceneManager.LoadScene("End");
        } else{
            //newssheep--to allow speaking to NPC again
            sheep.firstTime = true;

            if (sheep.complete)
            { //make star appear
                Debug.Log("star appears");
                newsStar.SetActive(true);
                sheep.isNPC = false;

                //TODO: get sheep to hand star--plce in front of player?
            }
        }

    }
}
