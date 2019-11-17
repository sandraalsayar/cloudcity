using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverMenuTimeIn : MonoBehaviour 
{
    //Number of seconds till game over
    public int timeout;
    public GameObject player;
    StarCollector starCollector;

    private CanvasGroup canvasGroup;

    // prints a Debug.LogError() if GetComponent() doesn’t find the component you are looking for
    private void Awake()
    {
        starCollector = player.GetComponent<StarCollector>();
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
        yield return new WaitForSeconds(waitTime+1); //+1 so that the timer goes down to 0 then shows gameover

        //disables GameOver Canvas when Player collects all 7 stars
        if (starCollector.starCount >= 7)
        {
            gameObject.SetActive(false);
        }
        else
        {

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

}


