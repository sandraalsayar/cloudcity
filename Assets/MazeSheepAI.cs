/*
	MazeSheepAI attached to Sheep
	Influence on Sheep, Player, and border
	Main author: Sandra
	Contains code that walk the sheep on waypoints and detects player close behind.
*/
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
		public GameObject border;
		private float timer;
		private bool turnAround;
		private bool winMaze;
		private bool looseMaze;
		public Rigidbody player;
		private Vector3 playerPosition;
		public static bool turnOffCollider;
		public Transform teleportLocation;

		private void Start() {
			myNavMeshAgent = GetComponent<NavMeshAgent>();
			anim = GetComponent<Animator>();
			player = GetComponent<Rigidbody>();
			timer = 0; // 5 seconds
			playerPosition = player.transform.position;
			turnOffCollider = false;

			if (anim == null) {
				Debug.Log("Animator could not be found");
			}
			currWaypoint = -1;
			keepGoing = true;
		// startFlag = MazeFlagCollisionCode.sheepFlag;

		// Debug.Log("wayoint was: " + currWaypoint);
			setNextWaypoint();
		}


		private void Update() {
		// If star entered the border, then start walking
			if (MazeFlagCollisionCode.sheepFlag == true) {
                anim.SetBool("PlayerClose", true);
				
				if (keepGoing & currWaypoint < 19) {
					if (currWaypoint == -1) {
						currWaypoint = 0;
						if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
							setNextWaypoint();
						}
					} else {
						if (BehindSphereColliderScript.StopMoving == true) {
							myNavMeshAgent.Stop();
							if(BehindSphereColliderScript.TurnAroundFlag == true) {
								transform.LookAt(playerPosition);
								Debug.Log("YOU LOOOOOSEEEE IN BACK");
								// STOP EVERYTHING & RESTART LEVEL HERE - Stop timer as well
							}
						} else if (BehindSphereColliderScript.StopMoving == false) {
							if(FrontBoxColliderScript.StopMoving == true) {
								myNavMeshAgent.Stop();
								Debug.Log("YOU LOOOOOSEEEE FROM THE FRONT");
							} else {
								myNavMeshAgent.Resume();
								if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
									setNextWaypoint();
								}
							}
						} 
					}
					
				}
			}
		}


		private void setNextWaypoint() {
		// Debug.Log("Im supposed to be called again and again but am I?????");
		// This decides which waypoint in the array the minion is going to next
		// waypoints.Length - 1
		// Debug.Log("Current waypoint index again us: " + currWaypoint);
			if (currWaypoint >= waypoints.Length - 1) {
				keepGoing = false;

			} else {

				if (MazeFlagCollisionCode.sheepFlag == true) {
					keepGoing = true;
					currWaypoint++;
					myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
				}
			}


			if (waypoints.Length == 0) {
				Debug.Log("The array contains no waypoints.");
			}
		}
	}





/////////////////////////////////////////////////////////////////////////////////////////
	// // if player hits sheep
	// void OnTriggerEnter(Collider other) {
	// 	// Debug.Log("Ok so im inside!");
	// 	if(other.gameObject.CompareTag("Player")) {
	// 		keepGoing = false;
	// 		myNavMeshAgent.Stop();
	// 	}
	// }

	// /*
	// Player is still standing to close to the sheep
	// Start timer. If time finishes, sheep turns around, player looses and resets
	// If player moves away before timer ends, timer resets
	// */
	// void OnTriggerStay(Collider other) {
	// 	if(other.gameObject.CompareTag("Player")) {
	// 		// If it's hit from behind
	// 		if(BehindSphereColliderScript.BehindFlag == true) {
	// 			timer += Time.deltaTime; // real time seconds
	// 			Debug.Log("TIMER IS = " + timer);
	// 			if (timer >= 5.0) {  // NOTE: Need to make this smaller but untill everything is implemented keep it high
	// 				// turn around completly and loose game
	// 				// Debug.Log("TIMER IS NOW 5!!!");
	// 				// Disable the front collider since it will turn around (double collision)
	// 				turnOffCollider = true;
	// 				Debug.Log("I TURNED AROUND MUWAAAHAHAHAHAHAHAHA");
	// 				Debug.Log("The player postion is  = " + playerPosition);
	// 				transform.LookAt(playerPosition);
	// 				Debug.Log("YOU LOOOOOSEEEE IN BACK");
	// 			}
	// 		} else if(FrontBoxColliderScript.frontBoxDisabled == true && FrontBoxColliderScript.FrontFlag == true) {
	// 			timer += Time.deltaTime; // real time seconds
	// 			if (timer >= 2.0) {
	// 				transform.LookAt(playerPosition);
	// 				Debug.Log("YOU LOOOOOSEEEE IN FRONT");
	// 			}
	// 		}
	// 	}
	// }

	// // Player moved out of shot and is not in danger
	// void OnTriggerExit(Collider other) {
	// 	timer = 0;
	// 	keepGoing = true;
	// 	myNavMeshAgent.Resume();

	// }
// }



