using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepThinking : MonoBehaviour
{
    AudioSource audioSource;
    public bool isTalking;
    public bool audioPlayedOnce;
    public AudioClip audio_clip;
    TreehintSheep treeHintSheep;

    // Start is called before the first frame update
    void Start()
    {
        treeHintSheep = GetComponent<TreehintSheep>();
        isTalking = treeHintSheep.isNPC;
        audioSource = GetComponent<AudioSource>();
    
    }

    private void Update()
    {
        isTalking = treeHintSheep.isNPC;
        if (isTalking && !audioSource.isPlaying && !audioPlayedOnce)
        {
            audioSource.PlayOneShot(audio_clip, 0.7f);
            audioPlayedOnce = true;
        } else if (!isTalking)
        {
            audioPlayedOnce = false;
        }
      
    }

   
}
