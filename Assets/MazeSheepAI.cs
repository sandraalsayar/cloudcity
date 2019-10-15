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
	public AIState aiState;
	// public float distanceToMovingWaypoint;
	// public float lookAheadTime;
	// public Vector3 futureTarget;
	// public float stoppingDistance;

	public enum AIState {
		StationaryWaypointState,
		MovingWaypointState
	};

	private void Start() {
		myNavMeshAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		if (anim == null) {
			Debug.Log("Animator could not be found");
		}
		currWaypoint = -1;
		setNextWaypoint();

		aiState = AIState.StationaryWaypointState;
	}

	private void Update() {
		// Modify your MinionAI script in Update() to tell the animator the forward animation parameter
		// according to the navMeshAgent component’s speed
		anim.SetFloat("vely", myNavMeshAgent.velocity.magnitude / myNavMeshAgent.speed);

		switch (aiState) {
			case AIState.StationaryWaypointState:
			// check that myNavMeshAgent.pathPending is not true so that being near a waypoint doesn’t cause
			// rapid iteration through the waypoints before the new path can be found.
			if ((myNavMeshAgent.remainingDistance <= 1f) && (myNavMeshAgent.pathPending != true)) {
				if (currWaypoint == 4) {
					aiState = AIState.MovingWaypointState;
				} else {
					setNextWaypoint();
				}
			}
			break;
		}
	}

    // This method should analyze currWaypoint and waypoints to increment currWaypoint and loop back to zero
    // if currWaypoint is too big for the array. Also, the myNavMeshAgent should be updated of the new
	// waypoint with SetDestination(waypoints[currWaypoint].transform.position).
	// Add error handling if the array is zero length.
	private void setNextWaypoint() {

		// This decides which waypoint in the array the minion is going to next
		if (currWaypoint + 1 == waypoints.Length) {
			currWaypoint = 0;
		} else {
			currWaypoint++;
		}

		myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);

		if (waypoints.Length == 0) {
			Debug.Log("The array contains no waypoints.");
		}
	}

}

