using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	Used when player is caught
*/
public class RestartLevel : MonoBehaviour
{
	public void startGame() {
		SceneManager.LoadScene("SampleScene");
		
	}
}
