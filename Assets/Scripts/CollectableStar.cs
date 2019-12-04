using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStar : MonoBehaviour
{
    public string name; // name is the index and star number(specific)
    //Enter->stay
    //void OnTriggerStay(Collider c)
    //{
    //    if (c.attachedRigidbody != null)
    //    {
    //        StarCollector bc = c.attachedRigidbody.gameObject.GetComponent<StarCollector>();
    //        // only destroy object and increment if was X pressed

    //        if (bc != null)
    //        {
    //            // tells that you're in range of star
    //            //bc.canCollect = true;
    //            // only go through with picking up steps IF pickedup animation is complete
    //            if(bc.pickedUp){
    //            //EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);

    //                // Add to correct star index
    //                bc.stars[int.Parse(this.name)] = true;

    //                // Debug.Log("stars collected" + bc.stars[0]);
    //                Destroy(this.gameObject);
    //                bc.ReceiveStar();
    //            }

    //        }
    //    }
    //}

    //if just standing there when star appears
    void OnTriggerStay(Collider other){
        // tells that you're in range of star
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    if (other.attachedRigidbody != null)
        //    {
        //        StarCollector bc = other.attachedRigidbody.gameObject.GetComponent<StarCollector>();

        //        if (bc != null)
        //        {
        //            //NEW Collection Implementation
        //            if (bc.canCollect)
        //            { // only allow once it's revealed in spot
        //                bc.stars[int.Parse(this.name)] = true;

        //                // Debug.Log("stars collected" + bc.stars[0]);
        //                Destroy(this.gameObject);
        //                bc.ReceiveStar();
        //            }
        //        }

        //    }
        //}

        if (other.gameObject.CompareTag("Player"))
        {
            //bc.canCollect = true;
            StarCollector bc = other.attachedRigidbody.gameObject.GetComponent<StarCollector>();
            //NEW Collection Implementation
            int starNum = int.Parse(this.name);
            //collect the star IF it has been allowed (after floating up)
            //OR it's one of the plain stars
            if (bc.canCollect
               || starNum == 0
               || starNum == 1
               || starNum == 4
               || starNum == 6
               //|| starNum == 5
              )
            { // only allow once it's revealed in spot
                bc.stars[int.Parse(this.name)] = true;
                // Debug.Log("stars collected" + bc.stars[0]);
                Destroy(this.gameObject);
                bc.ReceiveStar();
            }
        }
    }
    //void OnTriggerEnter(Collider other){
    //    // tells that you're in range of star


    //    if(other.gameObject.CompareTag("Player")){
    //        //bc.canCollect = true;
    //        StarCollector bc = other.attachedRigidbody.gameObject.GetComponent<StarCollector>();
    //        //NEW Collection Implementation
    //        int starNum = int.Parse(this.name);
    //        //collect the star IF it has been allowed (after floating up)
    //        //OR it's one of the plain stars
    //        if (bc.canCollect
    //           || starNum == 0
    //           || starNum == 1
    //           || starNum == 4
    //           || starNum == 6
    //           || starNum == 5
    //          )
    //        { // only allow once it's revealed in spot
    //            bc.stars[int.Parse(this.name)] = true;
    //            // Debug.Log("stars collected" + bc.stars[0]);
    //            Destroy(this.gameObject);
    //            bc.ReceiveStar();
    //        }
    //    }
    //}
    void OnTriggerExit(Collider other)
    {
        // tells that you're in range of star
        StarCollector bc = other.attachedRigidbody.gameObject.GetComponent<StarCollector>();

        //if(other.gameObject.CompareTag("Player"))
        //{
        //    bc.canCollect = false;
        //}
    }
}
