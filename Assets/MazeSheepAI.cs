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
		public GameObject sheep;
		public static bool turnOffCollider;
		public static bool Lose;
		// public GameObject tutorialText;
		DialogueManager manager;

		public GameObject frontCollider;
		public GameObject backCollider;
		public GameObject questFailedText;
		public GameObject restart;

		public bool firstTime;
		public GameObject textCollider;

        //sound
        AudioSource audioSource;
        public AudioClip hmSound;
        bool audioPlayedOnce;

        //controlsUI
        public CanvasGroup controlGroup;
        public ControlsTracker controlType;

		private void Start() {
			myNavMeshAgent = GetComponent<NavMeshAgent>();
			// woodChopper = sheep.GetComponent<WoodChopperTextScript>();
			// manager = FindObjectOfType<DialogueManager>();
			anim = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            audioPlayedOnce = false;

			timer = 0; // 5 seconds

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
			if (textCollider.GetComponent<WoodChopperTextScript>().tutorialDone == true)
			{
              
				textCollider.SetActive(false);
				anim.SetTrigger("StartWalking");
				if (keepGoing & currWaypoint < 17)
				{
                 
					if (currWaypoint == -1)
					{
						currWaypoint = 0;
						if ((Vector3.Distance(transform.position, waypoints[currWaypoint].transform.position) < 2f ) && (!myNavMeshAgent.pathPending))
						{
							setNextWaypoint();
						}
					}
					else
					{
						// Turn on the collider if currwaypoint is 2 or more
						if (currWaypoint >= 2) {
							frontCollider.SetActive(true);
							backCollider.SetActive(true);

						}
						if (BehindSphereColliderScript.StopMoving == true) // that means player entered back zone 
						{
                            
                            myNavMeshAgent.Stop(); // stop sheep from moving
                            Debug.Log("hm?");
                            if (!audioSource.isPlaying && !audioPlayedOnce)
                            {
                                audioSource.PlayOneShot(hmSound , 0.7f);
                                audioPlayedOnce = true;
                            }

                   

							if (BehindSphereColliderScript.TurnAroundFlag == true)  // that means player stood in back zone for too long
							{
								//Sheep turns around fully -> GAMEOVER
								anim.SetBool("PlayerTooClose", true);
								Debug.Log("YOU LOOOOOSEEEE IN THE BACK");
								timer += Time.deltaTime; // wait a little before turning completly
								if (timer >= 2.0)
								{
									// Lose = true; // Pauses game
									Debug.Log("Timer = " + timer);
									this.transform.position = new Vector3((float)172.38, (float)0.12, (float)-27.64);
									player.GetComponent<Rigidbody>().transform.position = new Vector3((float)154.18, (float)0.12, (float)-29.38);
									// manager.tutorialDone = false;  // so you can talk to him again
									frontCollider.SetActive(false);
									backCollider.SetActive(false);
									currWaypoint = -1;
									BehindSphereColliderScript.StopMoving = false;
									BehindSphereColliderScript.TurnAroundFlag = false;
									timer = 0;
								}

							}
							else
							{
                              
								anim.SetBool("PlayerClose", true);
								// BehindSphereColliderScript.StopMoving = false;

							}
						}
						else if (BehindSphereColliderScript.StopMoving == false)
						{
							if(FrontBoxColliderScript.StopMoving == true)
							{
								timer += Time.deltaTime; // wait a little before turning completly
								if (timer >= 2.0) {
									// anim.SetBool("PlayerInFront", true);
									myNavMeshAgent.Stop(); // stop sheep moving
									Debug.Log("YOU LOOOOOSEEEE FROM THE FRONT");
									// Lose = true; // Pauses game

									this.transform.position = new Vector3((float)172.38, (float)0.12, (float)-27.64);
									player.GetComponent<Rigidbody>().transform.position = new Vector3((float)154.18, (float)0.12, (float)-29.38);
									// manager.tutorialDone = false;
									frontCollider.SetActive(false);
									backCollider.SetActive(false);
									currWaypoint = -1;
									FrontBoxColliderScript.StopMoving = false;
									timer = 0;

									// textCollider.GetComponent<WoodChopperTextScript>().firstTime = true; // to reset dialogue
								}

							}
							else
							{
                                audioPlayedOnce = false;
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
            Debug.Log("AI sheep stopped");
            //controlsUI disable
            controlGroup.interactable = false;
            controlGroup.blocksRaycasts = false;
            controlGroup.alpha = 0f;
            //unload text
            controlType.current = -1;
            controlType.num--;
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
				if (textCollider.GetComponent<WoodChopperTextScript>().tutorialDone == true) {
					keepGoing = true;
					currWaypoint++;
        				// Debug.Log("Im inside!! Currenwaypoint = " + currWaypoint);
					myNavMeshAgent.SetDestination(waypoints[currWaypoint].transform.position);
				}
			}
		}
	}
}
