using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerOn : MonoBehaviour
{
    public GameObject player;
    //public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //handles bouncing when moving with platform
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.SetParent(this.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = null;
        }
    }
}
