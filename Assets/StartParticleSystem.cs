using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticleSystem : MonoBehaviour
{
    public ParticleSystem system;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            system.Play();
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            system.Stop();
        }

    }


}
