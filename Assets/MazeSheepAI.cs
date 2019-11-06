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
		public static bool Lose;

		private void Start() {
			myNavMeshAgent = GetComponent<NavMeshAgent>();
			anim = GetComponent<Animator>();
			player = GetComponent<Rigidbody>();
			timer = 0; // 5 seconds
			playerPosition = player.transform.position;
			turnOffCollider = false;
			Lose = false;

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
				anim.SetTrigger("StartWalking");
				
				if (keepGoing & currWaypoint < 22) {
					if (currWaypoint == -1) {
						currWaypoint = 0;
						if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending)) {
							setNextWaypoint();
						}
					} else {
						if (BehindSphereColliderScript.StopMoving == true) {
							myNavMeshAgent.Stop();

							if (BehindSphereColliderScript.TurnAroundFlag == true && !Lose) { //Sheep turns around fully -> GAMEOVER

								anim.SetBool("PlayerTooClose", true);
								// Debug.Log("YOU LOOOOOSEEEE IN BACK");
								timer += Time.deltaTime;
								if (timer >= 2.0) {
									Lose = true; // Pauses game
								}
                                

                            } else {
                            	anim.SetBool("PlayerClose", true);

                            }
                        } else if (BehindSphereColliderScript.StopMoving == false) {
                        	if(FrontBoxColliderScript.StopMoving == true) {
                        		myNavMeshAgent.Stop();
                        		anim.SetBool("PlayerInFront", true);
                        		// Debug.Log("YOU LOOOOOSEEEE FROM THE FRONT");
                        		Lose = true;
                        	} else {
                        		myNavMeshAgent.Resume();
                        		anim.SetBool("PlayerClose", false);
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
		// Debug.Log("Current waypoint index again us: " + currWaypoint);
			// if the final waypoint is reached then stop
        	if (currWaypoint >= waypoints.Length - 1) {
        		keepGoing = false;
        	} else {
        		if (currWaypoint == 19) {
        			timer += Time.deltaTime;
        			if (timer >= 5.0) { 
        				keepGoing = true;
        				currWaypoint++;
        				myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
        			}
        		} else { 
        			if (MazeFlagCollisionCode.sheepFlag == true) {
        				keepGoing = true;
        				currWaypoint++;
        				myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
        			}
        		}
        	}
        }
    }


        	// if (waypoints.Length == 0) {
        	// 	Debug.Log("The array contains no waypoints.");
        	// }

