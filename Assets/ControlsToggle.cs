using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ControlsToggle : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    //public SpriteRenderer player;
    //void Awake()
    //{
    //    //canvasGroup = GetComponent<CanvasGroup>();

    //    //if (canvasGroup == null)
    //    //{
    //    //    Debug.LogError("Cannot find component");
    //    //}
    //}

    public void onControlClick(){
        Debug.Log("activate controls");
        //player.enabled = true;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        //Time.timeScale = 0f;
    }
    public void onBackClick(){
        Debug.Log("close controls");
        //player.enabled = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        //Time.timeScale = 1f;
    }
}
