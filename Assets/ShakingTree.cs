using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingTree : MonoBehaviour
{
    private Animation anim;

    private void OnTriggerEnter(Collider other)
    {
        anim = other.gameObject.GetComponent<Animation>();

        if (anim.isPlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Shaking");
            anim.Play("Shake");
        }
    }
}
