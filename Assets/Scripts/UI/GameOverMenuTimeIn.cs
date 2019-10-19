using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverMenuTimeIn : MonoBehaviour 
{
    //Number of seconds till game over
    public float timeout = 60f;

    private CanvasGroup canvasGroup;

    // prints a Debug.LogError() if GetComponent() doesn’t find the component you are looking for
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("Could not find component.");
        }
    }

    IEnumerator Start()
    {
        yield return StartCoroutine(TimeOut(timeout));
    }

    //Waits waitTime amount of seconds, then enables the canvas/menu to appear
    IEnumerator TimeOut(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (canvasGroup.interactable)
        {
            Time.timeScale = 1f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0f;
        }
        else
        {
            Time.timeScale = 0f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
    }

}


