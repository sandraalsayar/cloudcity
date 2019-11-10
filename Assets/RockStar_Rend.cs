using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStar_Rend : MonoBehaviour
{
    public string name; // name is the index and star number(specific)
    public Renderer rend;

    void Start() {
    	rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update() {
    	// Enable renderer accordingly
    	if (ActionRock.isTurnedOver) {
        	rend.enabled = true;
    	}
    }
}
