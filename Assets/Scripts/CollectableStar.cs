using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStar : MonoBehaviour
{
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
                bc.canCollect = true;
                // only go through with picking up steps IF pickedup animation is complete
                if(bc.pickedUp){
                //    //EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);
                    Destroy(this.gameObject);
                    bc.ReceiveStar();
                }

            }
        }
    }
}
