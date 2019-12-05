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
	public GameObject frontCollider;
	public  MazeSheepAI mazesheep; 

	void Start() {

		FrontCollisionFlag = false;
		StopMoving = false;
		mazesheep = gameObject.GetComponent<MazeSheepAI>();

	}

	// Notifies the sheep that the player has enetred from the back
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			FrontCollisionFlag = true;
			StopMoving = true;
		}
	}

    //// Player moved out of shot and is not in danger
    //void OnTriggerExit(Collider other)
    //{
    //    StopMoving = false;
    //    FrontCollisionFlag = false;
    //}
}
