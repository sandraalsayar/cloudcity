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
	public int currWaypoint;
	private bool go;
	// public float distanceToMovingWaypoint;
	// public float lookAheadTime;
	// public Vector3 futureTarget;
	// public float stoppingDistance;

	private void Start() {
		myNavMeshAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		if (anim == null) {
			Debug.Log("Animator could not be found");
		}
		currWaypoint = -1;
		go = true;
		setNextWaypoint();
	}

	private void Update() {
		if (go) {
			if ((Vector3.Distance(transform.position,waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
				Debug.Log("current " + waypoints[currWaypoint].transform.position + " distance " + myNavMeshAgent.remainingDistance + " position " + transform.position);
				setNextWaypoint();
			}

			
		}
	}


	private void setNextWaypoint() {

		// This decides which waypoint in the array the minion is going to next
		if (currWaypoint > waypoints.Length - 1) {
			go = false;
		} else {
			go = true;
			currWaypoint++;
		}

		myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
		

		if (waypoints.Length == 0) {
			Debug.Log("The array contains no waypoints.");
		}
	}

}

