using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStar : MonoBehaviour
{
    public string name; // name is the index and star number(specific)
    //Enter->stay
    void OnTriggerStay(Collider c)
    {
        if (c.attachedRigidbody != null)
        {
            StarCollector bc = c.attachedRigidbody.gameObject.GetComponent<StarCollector>();
            // only destroy object and increment if was X pressed

            if (bc != null)
            {
                // tells that you're in range of star
                //bc.canCollect = true;
                // only go through with picking up steps IF pickedup animation is complete
                if(bc.pickedUp){
                //EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);

                    // Add to correct star index
                    bc.stars[int.Parse(this.name)] = true;

                    // Debug.Log("stars collected" + bc.stars[0]);
                    Destroy(this.gameObject);
                    bc.ReceiveStar();
                }

            }
        }
    }
    void OnTriggerEnter(Collider other){
        // tells that you're in range of star
        StarCollector bc = other.attachedRigidbody.gameObject.GetComponent<StarCollector>();

        if(other.gameObject.CompareTag("Player")){
            bc.canCollect = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        // tells that you're in range of star
        StarCollector bc = other.attachedRigidbody.gameObject.GetComponent<StarCollector>();

        if(other.gameObject.CompareTag("Player"))
        {
            bc.canCollect = false;
        }
    }
}
