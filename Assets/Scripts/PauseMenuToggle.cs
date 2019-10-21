using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script will be acting on the CanvasGroup so add a component requirement to the class
[RequireComponent(typeof(CanvasGroup))]
public class PauseMenuToggle : MonoBehaviour {

	private CanvasGroup canvasGroup;

	void Awake() {
		canvasGroup = GetComponent<CanvasGroup>();

		if (canvasGroup == null) {
			Debug.LogError("Cannot find component");
		}
	}


	void Update() {
		if (Input.GetKeyUp (KeyCode.Escape)) {
			if (canvasGroup.interactable) {
				canvasGroup.interactable = false;
				canvasGroup.blocksRaycasts = false;
				canvasGroup.alpha = 0f;
				Time.timeScale = 1f;
				
			} else {
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Time.timeScale = 0f;
			}
		}
	}

}
