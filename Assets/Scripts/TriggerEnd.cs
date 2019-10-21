using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnd : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    void OnTriggerEnter(Collider c){
        //starcount hardcoded to be 2 for now
        if (c.attachedRigidbody != null && c.CompareTag("Player") && c.attachedRigidbody.gameObject.GetComponent<StarCollector>().starCount==2)
        {
            Debug.Log("endScene");
            SceneManager.LoadScene("End");
        }
    }
}
