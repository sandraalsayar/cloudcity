using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class StarCollector : MonoBehaviour
{
    //public bool hasBall = false;
    public int starCount = 0;
    public bool canCollect = false;
    public bool pickedUp = false;

    public Text starScore;

    public bool[] stars;

    public void Start()
    {
        stars = new bool[4];
        starScore.text = starCount.ToString();
    }
    public void ReceiveStar()
    {
        starCount++;
        canCollect = false;
        pickedUp = false;
        starScore.text = starCount.ToString();
    }
}

