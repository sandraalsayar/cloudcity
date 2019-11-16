using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(!other.gameObject.CompareTag("Player")){
            Debug.Log("destory newspaper");
            Destroy(this.gameObject);
        }
    }
}
