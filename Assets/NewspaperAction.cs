using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperAction : MonoBehaviour
{

    // Start is called before the first frame update
	Animator anim;
    //refernce to star collector class
	StarCollector starCollector;
    //reference to player
	public GameObject player;
    public GameObject newspaper;
    public GameObject newsParent;
    GameObject news;
	public bool isThrown;

    // Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
		starCollector = player.GetComponent<StarCollector>();
		starCollector.isThrown = false;

	}

    // Update is called once per frame
	void Update()
	{
        if (starCollector.isThrown)
        {
            Debug.Log("newspaper thrown");
            // instantiates newspaper
            news = Instantiate(newspaper, transform.position +transform.forward ,Quaternion.identity);
            news.gameObject.SetActive(true);
            //trigger newspaper flying
            news.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //modify this to change how much its thrown by in conjunction with the height of the gameobject in unity inspector
            news.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 10.0f;

            starCollector.isThrown = false;

        }
	}

 
}
