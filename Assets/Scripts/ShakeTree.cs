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

    //Audio
    AudioSource audioSource;
    public AudioClip[] audioClips;
    public bool audioPlayedOnce;
    public bool shakeAudioPlayedOnce;

    public GameObject search;

    void Start()
    {
        isNearTree = false;
        anim = GetComponent<Animator>();
        starCollector = player.GetComponent<StarCollector>();
        treeStarAnim = treeStar.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioPlayedOnce = false;
        shakeAudioPlayedOnce = false;

    }

    private void Update()
    {
        // if you are near the tree and the PLAYER's animation has played, trigger animation for tree
        // make star appear
        if (isNearTree && starCollector.interacted)
        {
            //trigger tree shaking animation
            anim.SetTrigger("isShaken");

            //play tree shaking sound if it hasn't played yet
            if (!audioSource.isPlaying && !shakeAudioPlayedOnce)
            {
                audioSource.PlayOneShot(audioClips[1], 0.7f);
                shakeAudioPlayedOnce = true;
            }

            //make star fly/fall down
            // treeStar.SetActive(true);
            treeStarAnim.SetTrigger("TreeIsShaken");
            starCollector.interacted = false;
         
            //play star sparkle sound
            if (!audioPlayedOnce)
            {
                audioSource.PlayOneShot(audioClips[0], 0.7f);
                audioPlayedOnce = true;
            }
            search.SetActive(false);


        }
    }
    


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isNearTree = true;
                starCollector.isNearTree = true;
                search.SetActive(true);

            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isNearTree = false;
                starCollector.isNearTree = false;
                search.SetActive(false);

            }
        }
}
