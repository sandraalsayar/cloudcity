using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsDuringDialogue : MonoBehaviour
{
    public float wait_sec;
    AudioSource audioSource;
    public bool isTalking;
    TreehintSheep treeHintSheep;

    // Start is called before the first frame update
    void Start()
    {
        treeHintSheep = GetComponent<TreehintSheep>();
        isTalking = treeHintSheep.isNPC;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        while (isTalking)
        {
           
            isTalking = treeHintSheep.isNPC;
            Debug.Log(isTalking);
            audioSource.Play(0);
            yield return new WaitForSeconds(wait_sec);
        }

    }
}
