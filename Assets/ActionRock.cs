using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRock : MonoBehaviour
{
	public Rigidbody rock;
	public Rigidbody player;
	public Animator anim;	
	private bool isNearRock;
	public bool isTurnedOver;
	// public String openText;

	void Start() {
		rock = GetComponent<Rigidbody>();
		player = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isNearRock = false;
		isTurnedOver = false;
		// openText = "Press T.";
	}

	// When player presses "t" the rock turns over
	void Update() {
		// check if player is near rock and rock isn't turned over yet
		if (isNearRock && isTurnedOver == false) {
			Debug.Log("Ok i'm isnide!");
			if(Input.GetKeyDown("x"))
			{
				Debug.Log("Player pressed X!");
				anim.SetTrigger("isTurnedOver");
				isTurnedOver = true;
				// animator.SetBool("TurnOver", isTurnedOver);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			isNearRock = true;
			Debug.Log("Player is inside the zone!");
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			isNearRock = false;
			Debug.Log("Player is outside the zone!");
		}
	}
	
}
