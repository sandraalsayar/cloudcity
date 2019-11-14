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
    public bool starFloated;

    void Start()
    {
		anim = GetComponent<Animator>();
		// CanFloat = false;
		starIsFloating = false;
		starFloated = false;
		isNearRock = false;
        starCollector = player.GetComponent<StarCollector>();

    }

    void Update()
    {
		if (ActionRock.isTurnedOver == true) {
			anim.SetBool("starIsFloating", true);
			// CanFloat = true;
			// starIsFloating = true;
			starFloated = true;
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

}
