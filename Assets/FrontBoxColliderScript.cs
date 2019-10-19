/*
	FrontBoxColliderScript attached to empty game object of sheep
	Main author: Sandra
	Detects player in front.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBoxColliderScript : MonoBehaviour
{

	public static bool FrontCollisionFlag;
	public static bool StopMoving;
	public static bool TurnAroundFlag;
	// public Animator anim;	


	void Start() {

		FrontCollisionFlag = false;
		StopMoving = false;

		// anim = GetComponent<Animator>();
		// if (anim == null) {
		// 	Debug.Log("Animator could not be found");
		// }
	}

	// Notifies the sheep that the player has enetred from the back
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			FrontCollisionFlag = true;
			StopMoving = true;

		}
	}
}
