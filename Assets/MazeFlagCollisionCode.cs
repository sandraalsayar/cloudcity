/*
	MazeFlagCollisionCode is attached to the border of maze (invisible box object)
	Influence on Sheep, Player, and border
	Main author: Sandra
	Detects when player crosses the border
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeFlagCollisionCode : MonoBehaviour {

	public GameObject border;
	public Rigidbody player;
	public Rigidbody sheep;
	public static bool sheepFlag;


	void Start() {
		
		border = GetComponent<GameObject>();
		player = GetComponent<Rigidbody>();
		sheep = GetComponent<Rigidbody>();
		sheepFlag = false;

	}

	// Notifies the sheep that the player has enetred
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			sheepFlag = true;
		}
	}

}
