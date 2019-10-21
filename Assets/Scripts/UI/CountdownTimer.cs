using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Countdown Timer:
/// 
/// Displays countdown value on GUI
/// 
/// countdown- value countdown starts from
/// currCountdown- current countdown value
/// </summary>

public class CountdownTimer : MonoBehaviour
{
    private float countdown;
    private Text countdownText;
    public float currCountdown;

    IEnumerator Start()
    {
        GameObject GameOverCanvas = GameObject.Find("GameOverCanvas"); //Find the gameobject that the script is attached to
        GameOverMenuTimeIn gameOverScript = GameOverCanvas.GetComponent<GameOverMenuTimeIn>(); //Access script by using GetComponent
        countdown = gameOverScript.timeout; //Now can access variables in script
        yield return StartCoroutine(StartCountdown(countdown));
    }

    IEnumerator StartCountdown(float countdown)
    {
        currCountdown = countdown;

        while (currCountdown >= 0)
        {

            Debug.Log("countdown: " + currCountdown);
            countdownText = gameObject.GetComponent<Text>();
            countdownText.text = "Timer: "+ currCountdown+ " seconds";

            if (currCountdown <= 15)
            {
                countdownText.color = Color.red;
            }
            yield return new WaitForSeconds(1.0f);
            currCountdown--;
        }
    }
}
