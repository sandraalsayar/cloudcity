using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemDownTrigger : MonoBehaviour
{
    private Animator anim;
    private Animator star_anim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            anim = other.gameObject.transform.parent.gameObject.GetComponent<Animator>();
            anim.SetBool("ReachedDestination", true);
            star_anim = other.gameObject.GetComponent<Animator>();
            star_anim.SetTrigger("NearBench");

        }
     
    }
}
