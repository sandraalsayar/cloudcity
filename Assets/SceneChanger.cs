using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update

    public void FadeScene(){
        anim.SetTrigger("fadeOut");
    }
    public void onFadeComplete(){
        SceneManager.LoadScene("SampleScene");
    }
}
