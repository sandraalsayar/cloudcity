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

    //Audio
    AudioSource audioSource;
    public bool audioPlayedOnce;


    //star
    public Animator floatAnim;

    //
    public GameObject search;

    void Start()
    {
        isNearPlant = false;
        anim = GetComponent<Animator>();
        starCollector = player.GetComponent<StarCollector>();
        audioSource = GetComponent<AudioSource>();
        audioPlayedOnce = false;

    }

    // Update is called once per frame
    void Update()
    {
        // if you are near the plant and the PLAYER's animation has played, trigger animation for plant
        // make star appear

        if (isNearPlant && starCollector.interacted)
        {
            //trigger plant flying animation
            //make star pop out in animation
            anim.SetTrigger("isYanked");
            //interaction icon
            search.SetActive(false);
            if (!audioSource.isPlaying && !audioPlayedOnce)
            {
                audioSource.Play(0);
                audioPlayedOnce = true;
            }
        

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

            //interaction icon
            search.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isNearPlant = false;
            starCollector.isNearPlant = false;
            //interaction icon
            search.SetActive(false);
        }
    }

    //called at end of plant flying animation
    public void FadePlant(){

        starCollector.interacted = false;
        starCollector.isNearPlant = false;
        Destroy(this.gameObject);
    }

    //activate star event
    public void ActivateStar(){
        plantStar.SetActive(true);
        floatAnim.SetTrigger("float");
    }
}
