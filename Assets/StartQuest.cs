using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class StartQuest : MonoBehaviour
{
    public GameObject newsSheep;
    NewspaperSheep sheep;

    //public Text newsText;
    //public Text newsProgress;
    //public Text newsDelivery;
    //public Text newsRemaining;
    //public Text numRemaining;
    public CanvasGroup canvasGroup;

    public bool nearBox;
    // Start is called before the first frame update
    void Start()
    {
        sheep = newsSheep.GetComponent<NewspaperSheep>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && nearBox && !sheep.quest && sheep.sheepTalked){
            sheep.quest = true;
            //news related text shows on HUD to signify quest has begun
            //newsText.gameObject.SetActive(true);
            //newsProgress.gameObject.SetActive(true);
            //newsDelivery.gameObject.SetActive(true);
            //newsRemaining.gameObject.SetActive(true);
            //numRemaining.gameObject.SetActive(true);

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
        if(sheep.complete){ //when quest is over, remove HUD
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered box");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("canstartQuest");
            nearBox = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("left box area");
            nearBox = false;
        }
    }
}
