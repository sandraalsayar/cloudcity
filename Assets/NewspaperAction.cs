using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperAction : MonoBehaviour
{
	// counters of how many newspapers were delievred to red, pink, orange, and blue houses
	// private int redHouseCounter;
	// private int pinkHouseCounter;
	// private int orangeHouseCounter;
	// private int blueHouseCounter;

    // Start is called before the first frame update
	Animator anim;
    //refernce to star collector class
	StarCollector starCollector;
    //reference to player
	public GameObject player;
    public GameObject newspaper;
    //GameObject news;
	public bool isThrown;

    // Start is called before the first frame update
	void Start()
	{
		// redHouseCounter = 0;
		// pinkHouseCounter = 0;
		// orangeHouseCounter = 0;
		// blueHouseCounter = 0;
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
            //trigger newspaper flying animation
            //anim.SetTrigger("isNewspaperFlying");
            //newspaper = Instantiate(newspaper); doesnt work
            newspaper.SetActive(true);
            newspaper.GetComponent<Rigidbody>().useGravity = true;
            newspaper.GetComponent<Rigidbody>().velocity = transform.forward * 10.0f;
            starCollector.isThrown = false;

        }
        //if(newspaper && newspaper.transform.position.y <= 0){
        //    Destroy(newspaper);
        //}

	}

	void OnCollisionEnter(Collision other)
	{
		// If we want to make it so that he needs to deliver certain amounts of newspapers to certain houses, then use this
		// if (other.gameObject.CompareTag("RedHouse")) {
		// 	redHouseCounter++;
		// } else if (other.gameObject.CompareTag("PinkHouse")) {
		// 	pinkHouseCounter++;
		// } else if (other.gameObject.CompareTag("OrangeHouse")) {
		// 	orangeHouseCounter++;
		// } else if (other.gameObject.CompareTag("BlueHouse")) {
		// 	blueHouseCounter++;
		// }

		if (other.gameObject.CompareTag("RedHouse") || other.gameObject.CompareTag("PinkHouse")
			|| other.gameObject.CompareTag("OrangeHouse") || other.gameObject.CompareTag("BlueHouse"))
		{
			starCollector.newsDelivered++;
		} 
	}

	//called at end of newspaper flying animation
	public void FadeNewspaper() {
        //TODO: fade away newspaper and then destroy
		Destroy(this.gameObject);
	}
}
