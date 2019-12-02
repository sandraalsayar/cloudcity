using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowCollection : MonoBehaviour
{
    public GameObject player;
    StarCollector starCollector;

    // Start is called before the first frame update
    void Start()
    {
        starCollector = player.GetComponent<StarCollector>();
        
    }

    public void AllowCollecting(){
        starCollector.canCollect = true;
    }
}
