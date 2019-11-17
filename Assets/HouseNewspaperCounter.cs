/*
 Attach this script to each house in the neighberhood
 */
 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class HouseNewspaperCounter : MonoBehaviour
 {
	// Add a script on each house that takes into account how many newspapers needed,
	// how many delivered, and if more than needed are delivered
 	public int newspapersNeeded;
 	public int newspapersHave;
 	public bool haveEnough;
 	public bool haveMore;
 	public bool haveLess;

 	public GameObject player;
	//refernce to star collector class
 	StarCollector starCollector;


 	void Start() {
 		newspapersHave = 0;
 		haveEnough = false;
 		haveMore = false;
 		haveLess = true;
 		starCollector = player.GetComponent<StarCollector>();
 	}
    // Update is called once per frame
 	void Update()
 	{
 		if (newspapersHave == newspapersNeeded) {
 			haveEnough = true;
 			haveMore = false;
 			haveLess = false;
 		} else if (newspapersHave > newspapersNeeded) {
 			haveEnough = false;
 			haveMore = true;
 			haveLess = false;
 		} else if (newspapersHave < newspapersNeeded) {
 			haveEnough = false;
 			haveMore = false;
 			haveLess = true;
 		}

 	}

 	void OnCollisionEnter(Collision other)
 	{
        //If we want to make it so that he needs to deliver certain amounts of newspapers to certain houses, then use this
 		if (other.gameObject.CompareTag("Newspaper")) {
        	// increment amount of newspapers that house now has
 			newspapersHave++;
        	// increment amount of newspapers delivered in total
 			starCollector.newsDelivered++;
 		}


 	}
 }

