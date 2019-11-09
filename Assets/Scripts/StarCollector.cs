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

    public bool interacted = false;
    //plant variable
    public bool isNearPlant = false;
    //tree variable
    public bool isNearTree = false;
    //rock variable
    public bool isNearRock = false;

    public Text starScore;
    public bool[] stars;

    public void Start()
    {
        stars = new bool[7];
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

