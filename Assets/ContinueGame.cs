using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CanvasGroup))]
public class ContinueGame : MonoBehaviour
{
    public CanvasGroup myCanvas;

    void Start() {
    	//myCanvas = GameObject.FindGameObjectsWithTag("PauseMenuCanvas");
    }
    public void Continue()
    {
        myCanvas.interactable = false;
        myCanvas.blocksRaycasts = false;
        myCanvas.alpha = 0f;
        Time.timeScale = 1f;
    }
}
