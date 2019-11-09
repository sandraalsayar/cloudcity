﻿using System.Collections;
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
    //sheep
    //public bool isNPC = false;
    public int newsDelivered = 0;
    public bool inQuest = false;

    public Text starScore;
    public Text newsDelivery;
    public bool[] stars;

    string nextStar = "";
    //endgame check
    public bool endgame;

    public void Start()
    {
        stars = new bool[7];
        starScore.text = starCount.ToString();
        newsDelivery.text = newsDelivered.ToString() + "/ 4"; //hardcode newspaper count total
        endgame = false;
    }
    public void ReceiveStar()
    {
        starCount++;
        //make star appear above head
        nextStar = "StarBoy/stars/Orbit/"+"star" + starCount;
        GameObject.Find(nextStar).SetActive(true);

        //reset vars
        canCollect = false;
        pickedUp = false;
        //update num in UI
        starScore.text = starCount.ToString();
    }
    //similar method for when delivering newspapers
}

