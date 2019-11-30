using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepCallingOut : MonoBehaviour
{
    public float wait_sec;
    AudioSource audioSource;
    public bool isTalking;
    FarmerSheep farmerSheep;
    

    // Start is called before the first frame update
    void Start()
    {
        farmerSheep = GetComponent<FarmerSheep>();
        isTalking = farmerSheep.isNPC;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());

    }


    IEnumerator PlaySound()
    {
        while (!isTalking)
        {
            isTalking = farmerSheep.isNPC;
            audioSource.Play(0);
            yield return new WaitForSeconds(wait_sec);
        }
        
    }

}
