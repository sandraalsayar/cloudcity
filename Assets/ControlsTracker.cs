using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsTracker : MonoBehaviour
{
    public int num; 
    public int current;
    public string[] controls; //keeps track of the controls being shown
    public int frameUpdate;
    // Start is called before the first frame update
    public Text control;
    public GameObject player;

    void Start()
    {
        num = 0;
        current = -1;
        controls = new string[2];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(num>1){
            frameUpdate++;
            //alternate between the 2 texts
            if(frameUpdate>=50){
                current = current==0 ? 1 : 0;
                frameUpdate = 0;
            }
            control.text = controls[current];
        } else if(num>0){
            //set the text here
            //current is always which one is ONLY being shown
            if(current==1){
                if (player.GetComponent<StarCollector>().stars[0])
                {
                    control.text = controls[current];
                }
            } else if(current==0){
                control.text = controls[current];
            }


        }
    }
}
