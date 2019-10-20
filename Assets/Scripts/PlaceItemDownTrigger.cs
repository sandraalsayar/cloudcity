using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemDownTrigger : MonoBehaviour
{
    private Animator anim;
    public GameObject newStar;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            anim = other.gameObject.transform.parent.gameObject.GetComponent<Animator>();
            anim.SetBool("ReachedDestination", true);

            StartCoroutine(WaitUntilStarOnBench(other.gameObject));


        }
     
    }

    IEnumerator WaitUntilStarOnBench(GameObject star)
    {
        Debug.Log("Im waiting for ");
        yield return new WaitForSeconds(8);
        Destroy(star);
        newStar.SetActive(true);

    }
}
