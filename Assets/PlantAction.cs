using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAction : MonoBehaviour
{
    private bool isNearPlant;
    public GameObject plantStar;
    // Start is called before the first frame update
    Animator anim;
    //refernce to star collector class
    StarCollector starCollector;
    //reference to player
    public GameObject player;

    void Start()
    {
        isNearPlant = false;
        anim = GetComponent<Animator>();
        starCollector = player.GetComponent<StarCollector>();

    }

    // Update is called once per frame
    void Update()
    {
        // if you are near the plant and the PLAYER's animation has played, trigger animation for plant
        // make star appear
        if (isNearPlant && starCollector.interacted)
        {
            //trigger plant flying animation
            anim.SetTrigger("isYanked");
            //make star pop out
            plantStar.SetActive(true);

        }
    }
    // when you enter collision zone, set check that you're near the object to true
    // update starCollector's variable to true as well
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearPlant = true;
            starCollector.isNearPlant = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearPlant = false;
            starCollector.isNearPlant = false;
        }
    }

    //called at end of plant flying animation
    public void FadePlant(){
        //TODO: fade away plant and then destroy
        Destroy(this.gameObject);
        starCollector.interacted = false;
        starCollector.isNearPlant = false;
    }
}
