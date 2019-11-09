using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAction : MonoBehaviour
{
    private bool isNearPlant;
    public GameObject plantStar;
    // Start is called before the first frame update
    Animator anim;
    StarCollector starCollector;
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
        if (isNearPlant && starCollector.interacted)
        {
            //trigger plant flying animation
            anim.SetTrigger("isYanked");

            //make star pop out
            plantStar.SetActive(true);

        }
    }

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
