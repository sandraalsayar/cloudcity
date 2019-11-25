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
    public Animator playerAnim;

    public GameObject NewsSheep;
    NewspaperSheep sheep;
    public GameObject newsStar;
    public CanvasGroup newsPanel;

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
        playerAnim.SetBool("dialogue", true); //prevent dancing
        Debug.Log("start convo for" + d.name);
        nameText.text = d.name;
        //clear previous
        sentences.Clear();

        //load dialogue
        if(d.isCluster){ // if you have a cluster (load in one of the possible dialogues)
            int sent = Random.Range(0, d.sentences.Length); //chooses an index from the array
            sentences.Enqueue(d.sentences[sent]);
        } else { //load all
            foreach (string sent in d.sentences)
            {
                sentences.Enqueue(sent);
            }
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
        if (animator.GetBool("isOpen")) //only if the animator was open, close it
        {


            Debug.Log("end ofconvo");
            animator.SetBool("isOpen", false);
            playerAnim.SetBool("dialogue", false); //allow dancing

            if (starCollector.endgame)
            {
                Debug.Log("endScene");
                SceneManager.LoadScene("End");
            }
            else
            {
                //newssheep--to allow speaking to NPC again
                sheep.firstTime = true;

                //when you FIRST talk to the sheep before starting the quest, allow to interact with the box to get your newspapers
                if (!sheep.quest)
                {
                    Debug.Log("talked to the sheep");
                    sheep.sheepTalked = true;
                }

                if (sheep.complete)
                { //make star appear
                    Debug.Log("star appears");
                    newsStar.SetActive(true);
                    sheep.isNPC = false;
                    //make quest panel disappear
                    newsPanel.interactable = false;
                    newsPanel.blocksRaycasts = false;
                    newsPanel.alpha = 0f;
                    //TODO: get sheep to hand star--plce in front of player?
                }
            }
        }

    }
}
