using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PauseGame : MonoBehaviour
{
	private CanvasGroup canvasGroup;

	void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();

		if (canvasGroup == null) {
			Debug.LogError("Cannot find component");
		}
	}


	void Update() {

		if (MazeSheepAI.Lose == true) {
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Time.timeScale = 0f;  // this pauses any movement
		}
	}
}
