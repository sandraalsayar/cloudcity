using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollector : MonoBehaviour
{
    //public bool hasBall = false;
    public int starCount = 0;
    public bool canCollect = false;
    public bool pickedUp = false;

    public void ReceiveStar()
    {
        starCount++;
        Debug.Log("count"+starCount);
        canCollect = false;
        pickedUp = false;

    }
}

