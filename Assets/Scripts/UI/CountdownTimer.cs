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
    private int countdown;
    private Text countdownText;
    private int minutes;
    private int seconds;
    public int currCountdown;

    IEnumerator Start()
    {
        GameObject GameOverCanvas = GameObject.Find("GameOverCanvas"); //Find the gameobject that the script is attached to
        GameOverMenuTimeIn gameOverScript = GameOverCanvas.GetComponent<GameOverMenuTimeIn>(); //Access script by using GetComponent
        countdown = gameOverScript.timeout; //Now can access variables in script
        yield return StartCoroutine(StartCountdown(countdown));
    }

    IEnumerator StartCountdown(int countdown)
    {
        currCountdown = countdown;

        while (currCountdown >= 0)
        {

            // Debug.Log("countdown: " + currCountdown);
           //compute minutes from seconds if over 59 seconds
           if (currCountdown > 59)
            {
                minutes = currCountdown / 60;
                seconds = currCountdown - (minutes * 60);
            } else
            {
                minutes = 0;
                seconds = currCountdown;
            }
       
            countdownText = gameObject.GetComponent<Text>();

            if (seconds < 10 && minutes < 10)
            {
                countdownText.text = "Timer: 0" + minutes + " : 0" + seconds;
            } else if (seconds < 10)
            {
                countdownText.text = "Timer: " + minutes + " : 0" + seconds;
            } else if (minutes < 10)
            {
                countdownText.text = "Timer: 0" + minutes + " : " + seconds;

            } else
            {
                countdownText.text = "Timer: " + minutes + " : " + seconds;
            }
            

            if (currCountdown <= 15)
            {
                countdownText.color = Color.red;
            }
            yield return new WaitForSeconds(1.0f);
            currCountdown--;
        }
    }
}
