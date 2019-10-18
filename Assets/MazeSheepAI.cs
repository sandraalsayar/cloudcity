using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MazeSheepAI : MonoBehaviour
{

	private NavMeshAgent myNavMeshAgent;
	public Animator anim;	
	public GameObject[] waypoints;
	private int currWaypoint;
	private bool keepGoing;
	public GameObject box;
	private bool flag;

	private void Start() {
		myNavMeshAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		box = GetComponent<GameObject>();

		if (anim == null) {
			Debug.Log("Animator could not be found");
		}
		currWaypoint = -1;
		keepGoing = true;
		// flag = MazeFlagCollisionCode.sheepFlag;

		// Debug.Log("wayoint was: " + currWaypoint);
		setNextWaypoint();
	}


	private void Update() {
		if (MazeFlagCollisionCode.sheepFlag == true) {
			if (keepGoing & currWaypoint < 19) {
				// Debug.Log("Current waypoint index is: " + currWaypoint);
				if (currWaypoint == -1) {
					currWaypoint = 0;
					// Debug.Log("At least i got here looooool");
					if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
						// Debug.Log("DID I GET HERE FIRST?");
						setNextWaypoint();
						// Debug.Log("DID I GET HERE TOO?");
					}
				} else {
					if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
						// Debug.Log("DID I GET HERE FIRST?");
						setNextWaypoint();
						// Debug.Log("DID I GET HERE TOO?");
					}
				}
			}
		}
	}

		// if (keepGoing && currWaypoint < 19) {
		// 	if ((Vector3.Distance(transform.position,waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
		// 		// Debug.Log("current " + waypoints[currWaypoint].transform.position + " distance " + myNavMeshAgent.remainingDistance + " position " + transform.position);
		// 		// Debug.Log("Current waypoint index is: " + currWaypoint);
		// 		setNextWaypoint();
		// 	}



	private void setNextWaypoint() {

		// This decides which waypoint in the array the minion is going to next
		// waypoints.Length - 1
		// Debug.Log("Current waypoint index again us: " + currWaypoint);
		if (currWaypoint >= waypoints.Length - 1) {
			keepGoing = false;
			// Debug.Log("WHY AM I HERE");
		} else {
			// Debug.Log("WHY AM I HERE TOO");
			if (MazeFlagCollisionCode.sheepFlag == true) {
				// Debug.Log("WHY AM I HERE THREE");
				keepGoing = true;
				currWaypoint++;
				// Debug.Log("Now it turnd: " + currWaypoint);
				myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
			}
		}


		if (waypoints.Length == 0) {
			Debug.Log("The array contains no waypoints.");
		}
	}
}



