
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour
{

	public int index;
	public string sceneName;

	void onCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Player")) {
		Debug.Log("vp;;");
			SceneManager.LoadScene("MiniGame");

		}
	}
}

