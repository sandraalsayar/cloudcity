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
		public int currWaypoint;
		private bool keepGoing;
		public GameObject border;
		private float timer;
		private bool turnAround;
		private bool winMaze;
		private bool looseMaze;
		public Rigidbody player;
		public GameObject npc;
		private Vector3 playerPosition;
		public static bool turnOffCollider;
		public static bool Lose;
		// WoodChopperTextScript woodChopper;
		DialogueManager manager;

		public GameObject frontCollider;
		public GameObject backCollider;
		public GameObject questFailedText;
		public GameObject restart;

		public bool firstTime;

		private void Start() {
			myNavMeshAgent = GetComponent<NavMeshAgent>();
			// woodChopper = npc.GetComponent<WoodChopperTextScript>();
			manager = FindObjectOfType<DialogueManager>();
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

			backCollider.SetActive(false);
			frontCollider.SetActive(false);

			firstTime = true;
			
			setNextWaypoint();
		}


		private void Update() {
		// If star entered the border, then start walking
			// if (MazeFlagCollisionCode.sheepFlag == true) {

			// If conversation with Star is over, start walking
			if (manager.tutorialDone == true)
			{
				// Debug.Log("Currenwaypoint is: " + currWaypoint); //0
				anim.SetTrigger("StartWalking");
				
				if (keepGoing & currWaypoint < 17)
				{
					// Debug.Log("Currenwaypoint is: " + currWaypoint); // 0
					if (currWaypoint == -1)
					{
						// Debug.Log("IM HEREEEEEEE");
						currWaypoint = 0;
						// Debug.Log("Currenwaypoint should be 0 but it's: " + currWaypoint); // 0
						// Debug.Log("Distance " + (Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position)));
						if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending))
						{
							// Debug.Log("Again, Currenwaypoint should be 0 but it's: " + currWaypoint); // 0
							setNextWaypoint();
						}
					}
					else
					{
						// Turn on the collider if currwaypoint is 1 or more
						if (currWaypoint >= 3) {
							frontCollider.SetActive(true);
							backCollider.SetActive(true);
						}
						
						if (BehindSphereColliderScript.StopMoving == true)
						{
							myNavMeshAgent.Stop();

							if (BehindSphereColliderScript.TurnAroundFlag == true && !Lose)
							{
							//Sheep turns around fully -> GAMEOVER
								anim.SetBool("PlayerTooClose", true);
								Debug.Log("YOU LOOOOOSEEEE IN BACK");
								timer += Time.deltaTime; // wait a little before turning completly
								if (timer >= 2.0)
								{
									// Lose = true; // Pauses game
									if (firstTime)
									{
										questFailedText.GetComponent<TextboxToggle>().TriggerDialogue();
										firstTime = false;
									}
									else
									{
										FindObjectOfType<DialogueManager>().DisplayNextSentence();
									} 
									restart.GetComponent<GameStarter>().StartGame();
									// firstTime = true;
								}
								// questFailedText.GetComponent<TextboxToggle>().TriggerDialogue();
							}
							else
							{
								anim.SetBool("PlayerClose", true);

							}
						}
						else if (BehindSphereColliderScript.StopMoving == false)
						{
							if(FrontBoxColliderScript.StopMoving == true)
							{
								myNavMeshAgent.Stop();
								anim.SetBool("PlayerInFront", true);
								Debug.Log("YOU LOOOOOSEEEE FROM THE FRONT");
								// Lose = true; // Pauses game
								// restart.GetComponent<GameStarter>().StartGame();

								if (firstTime)
								{
									questFailedText.GetComponent<TextboxToggle>().TriggerDialogue();
									firstTime = false;
								}
								else
								{
									FindObjectOfType<DialogueManager>().DisplayNextSentence();
								} 
								restart.GetComponent<GameStarter>().StartGame();
								// firstTime = true;
							}
							else
							{
								myNavMeshAgent.Resume();
								anim.SetBool("PlayerClose", false);
								if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending))
								{
									setNextWaypoint();
								}
							}
						} 
					}
				}
			}
		}

		private void setNextWaypoint() {
			// if the final waypoint is reached then stop
			if (currWaypoint >= waypoints.Length - 1) {
				keepGoing = false;
			} else {
				if (currWaypoint == 15) {
					timer += Time.deltaTime;
					if (timer >= 5.0) { 
						keepGoing = true;
						currWaypoint++;
        				// Debug.Log("Currenwaypoint = " + currWaypoint);
						myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
					}
				} else { 
					if (manager.tutorialDone == true) {
						keepGoing = true;
						currWaypoint++;
        				// Debug.Log("Im inside!! Currenwaypoint = " + currWaypoint);
						myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
					}
				}
			}
		}
	}


   //          private void setNextWaypoint() {
			// // if the final waypoint is reached then stop
   //      	if (currWaypoint >= waypoints.Length - 1) {
   //      		keepGoing = false;
   //      	} else {
   //      		if (currWaypoint == 15) {
   //      			timer += Time.deltaTime;
   //      			if (timer >= 5.0) { 
   //      				keepGoing = true;
   //      				currWaypoint++;
   //      				myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
   //      			}
   //      		} else { 
   //      			if (MazeFlagCollisionCode.sheepFlag == true) {
   //      				keepGoing = true;
   //      				currWaypoint++;
   //      				myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
   //      			}
   //      		}
   //      	}
   //      }
