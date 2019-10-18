using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeFlagCollisionCode : MonoBehaviour {

	public GameObject box;
	public Rigidbody player;
	public Rigidbody sheep;
	public static bool sheepFlag;


	void Start() {
		
		box = GetComponent<GameObject>();
		player = GetComponent<Rigidbody>();
		sheep = GetComponent<Rigidbody>();
		sheepFlag = false;

	}

	// make it spin when you get closer to it
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			sheepFlag = true;
		}
	}

}
