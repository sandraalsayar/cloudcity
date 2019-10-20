using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
	public void startGame() {
		Debug.Log("I should be restaring");
		SceneManager.LoadScene("SampleScene");
		Debug.Log("But im not!!!!");
		
	}
}
