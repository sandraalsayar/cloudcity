/*
	BehindSphereColliderScript attached to empty game object of sheep
	Main author: Sandra
	Detects player close behind.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehindSphereColliderScript : MonoBehaviour
{

	public static bool BehindCollisionFlag;
	public static bool StopMoving;
	public static bool TurnAroundFlag;
	public Animator anim;	
	private float timer;
	private bool turnAround;
	public static bool turnOffFrontCollider;
	public GameObject backCollider;
	public MazeSheepAI mazesheep;


	void Start() {

		BehindCollisionFlag = false;
		timer = 0; // 5 seconds
		StopMoving = false;
		TurnAroundFlag = false;
		mazesheep = gameObject.GetComponent<MazeSheepAI>();

		anim = GetComponent<Animator>();
		if (anim == null) {
			Debug.Log("Animator could not be found");
		}
	}


	// Notifies the sheep that the player has entered from the back
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			BehindCollisionFlag = true;
			StopMoving = true;
			TurnAroundFlag = false;

		}
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			// If it's hit from behind
			timer += Time.deltaTime; // real time seconds
			// Debug.Log("TIMER IS = " + timer);
			if (timer >= 5.0) {  // NOTE: Need to make this smaller but untill everything is implemented keep it high
				// turn around completly and loose game
				turnOffFrontCollider = true;
				TurnAroundFlag = true;
                timer = 0;
			}
		}
	}

    // Player moved out of shot and is not in danger
	void OnTriggerExit(Collider other) {
		timer = 0;
		StopMoving = false;
		TurnAroundFlag = false;
	}

}
