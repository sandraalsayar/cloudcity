using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	Used to return to main menu when sheep is caught or player pauses and choses return to main
*/
public class ReturnToMainMenu : MonoBehaviour
{
	public void startGame() {
		SceneManager.LoadScene("MainMenu");
	}
}
