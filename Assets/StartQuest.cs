using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartQuest : MonoBehaviour
{
    public GameObject newsSheep;
    NewspaperSheep sheep;

    public Text newsText;
    public Text newsProgress;

    public bool nearBox;
    // Start is called before the first frame update
    void Start()
    {
        sheep = newsSheep.GetComponent<NewspaperSheep>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && nearBox && !sheep.quest){
            sheep.quest = true;
            //news related text shows on HUD to signify quest has begun
            newsText.gameObject.SetActive(true);
            newsProgress.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered box");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("startQuest");
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
