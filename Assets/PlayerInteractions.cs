using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    public GameObject indication;
    //public Text indication;
    //public Button indication;
    //public Image indication;
    //// Start is called before the first frame update
    void Start()
    {
        if(indication){
            indication.SetActive(false);
        }
    }

    //// Update is called once per frame
    void Update()
    {
        //have the object point towards the camera/player/rotate to show the correct side
        //indication.transform.position = this.transform.position+ new Vector3(0f,2.5f,0f);
        indication.transform.position = this.transform.position + new Vector3(0f, 3.0f, 0f);
        indication.transform.LookAt(Camera.main.transform.position);
        indication.transform.Rotate(0,180,0);
    }

}
