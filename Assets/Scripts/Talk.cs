using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    public Text talkText;

    void Start(){
        talkText.enabled = false;
        //talkText.SetActive(false);
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            talkText.enabled = true;
        }


    }
}
