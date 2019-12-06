using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public Animator anim;

    public void FadeScene()
    {
        anim.SetTrigger("fadeOut");
    }
    public void onFadeComplete()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
