using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
	Used to return to main menu when sheep is caught or player pauses and choses return to main
*/
public class ReturnToMainMenu : MonoBehaviour
{
    public Animator anim;

    //public void FadeScene()
    //{
    //    anim.SetTrigger("fadeOut");
    //}
    //public void onFadeComplete()
    //{
    //    SceneManager.LoadScene("MainMenu");
    //    Time.timeScale = 1f;
    //}

	public void startGame() {
		SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
	}
}
