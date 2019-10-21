using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
public GameObject[] myCanvas;

void Start() {
	myCanvas = GameObject.FindGameObjectsWithTag("PauseMenuCanvas");
}
	// public void ContinueGame()
	// {
	// 	myCanvas.canvasGroup.interactable = true;
	// 	myCanvas.canvasGroup.blocksRaycasts = true;
	// 	myCanvas.canvasGroup.alpha = 1f;
	// 	Time.timeScale = 0f;
	// }


}
