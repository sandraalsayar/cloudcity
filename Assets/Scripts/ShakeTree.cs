using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTree : MonoBehaviour
{
    public GameObject treeStar;
    public GameObject player;

    //reference to star collector class
    StarCollector starCollector;

    private Animator anim;
    private Animator treeStarAnim;
    private bool isNearTree;

    void Start()
    {
        isNearTree = false;
        anim = GetComponent<Animator>();
        starCollector = player.GetComponent<StarCollector>();
        treeStarAnim = treeStar.GetComponent<Animator>();

    }

    private void Update()
    {
        // if you are near the tree and the PLAYER's animation has played, trigger animation for tree
        // make star appear
        if (isNearTree && starCollector.interacted)
        {
            //trigger tree shaking animation
            anim.SetTrigger("isShaken");


            //make star fly/fall down
            treeStar.SetActive(true);
            treeStarAnim.SetTrigger("TreeIsShaken");

        }
    }
    


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isNearTree = true;
                starCollector.isNearTree = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isNearTree = false;
                starCollector.isNearTree = false;
            }
        }
}
