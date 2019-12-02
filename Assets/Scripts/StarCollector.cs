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
    //sheep
    //public bool isNPC = false;
    public int newsDelivered = 0;
    public int maxNews = 22; // can be delivered
    public int newsGoal = 22;
    public int remainingNews;

    public bool inQuest = false;
    public bool isThrown = false;

    public Text starScore;
    public Text newsDelivery;
    public Text newsRemaining;

    public bool[] stars;

    string nextStar = "";
    //endgame check
    public bool endgame;
    public bool caughtStar;
    private Animator anim;
    public Animator textAnim;

    public void Start()
    {
        remainingNews = maxNews;
        stars = new bool[7];
        starScore.text = starCount.ToString();
        newsDelivery.text = newsDelivered.ToString() + "/" + newsGoal.ToString(); //hardcode newspaper count total
        newsRemaining.text = remainingNews.ToString() + "/" + maxNews.ToString();
        endgame = false;
        caughtStar = false;
        anim = GetComponent<Animator>();

    }

    public void Update() {
        newsDelivery.text = newsDelivered.ToString() + "/" + newsGoal.ToString();
        newsRemaining.text = remainingNews.ToString() + "/" + maxNews.ToString();
    }
    public void ReceiveStar()
    {
        starCount++;
        //make star appear above head (new player doesnt have this yet)
        nextStar = "StarBoy/stars/Orbit/"+"star" + starCount;
        GameObject.Find(nextStar).SetActive(true);

        //reset vars
        canCollect = false;
        //pickedUp = false;
        //update num in UI
        starScore.text = starCount.ToString();
        Debug.Log("received star");
        Debug.Log(canCollect);

        //do excited animation (new player)
        //anim.SetTrigger("pickUp");
        //with text showing
        textAnim.SetBool("isOpen", true);
        // dont allow movement
        caughtStar = true;
        StartCoroutine(WaitForAnim());
    }
    //similar method for when delivering newspapers
    public void ThrowNewspaper(){
        
        Debug.Log("throwing news paper here");
        isThrown = true;
        if(remainingNews>0){
            remainingNews--;
        }
        //remainingNews--; //decrement newspapers

    }

    //wait for collection animation
    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1.6f);
        //duration based on anim length but sometimes it's off anim.GetCurrentAnimatorStateInfo(0).length+ anim.GetCurrentAnimatorStateInfo(0).normalizedTime
        caughtStar = false;
        textAnim.SetBool("isOpen", false);
    }
}

