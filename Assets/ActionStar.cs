using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStar : MonoBehaviour
{
	private Animator anim;	
	// private bool CanFloat;
	public static bool starIsFloating;

	private bool isNearRock;
    public GameObject rockStar;

    //refernce to star collector class
    StarCollector starCollector;
    //reference to player
    public GameObject player;

    void Start()
    {
		anim = GetComponent<Animator>();
		// CanFloat = false;
		starIsFloating = false;

		isNearRock = false;
        starCollector = player.GetComponent<StarCollector>();

    }

    void Update()
    {
		// if (CanFloat == false && ActionRock.isTurnedOver == true) {
		// 	anim.SetTrigger("CanFloat");
		// 	CanFloat = true;
		// 	starIsFloating = true;
		// }

		// if you are near the rock and the PLAYER's animation has played, trigger animation for rock
        // make star appear
        if (isNearRock && starCollector.interacted)
        {
            //make star pop out
            rockStar.SetActive(true);

        }
    }

    // when you enter collision zone, set check that you're near the rock to true
    // update starCollector's variable to true as well
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearRock = true;
            starCollector.isNearRock = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearRock = false;
            starCollector.isNearRock = false;
        }
    }

    //called at end of Star animation
    public void FadePlant(){
        Destroy(this.gameObject);
        starCollector.interacted = false;
        starCollector.isNearRock = false;
    }
}
