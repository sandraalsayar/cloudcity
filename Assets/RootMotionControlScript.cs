using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

//require some things the bot control needs
[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
public class RootMotionControlScript : MonoBehaviour
{
    private Animator anim;	
    private Rigidbody rbody;


    private Transform leftFoot;
    private Transform rightFoot;


    private int groundContactCount = 0;

    float animationSpeed = 2f;
    float rootMovementSpeed = 1f;
    float rootTurnSpeed = 1f;

    public GameObject buttonObject;


    void Awake()
    {

        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.Log("Animator could not be found");

        rbody = GetComponent<Rigidbody>();

        if (rbody == null)
            Debug.Log("Rigid body could not be found");

    }


    // Use this for initialization
    void Start()
    {

            
    }
        

    void Update()
    {

        // set the Animator component speed to the scaler animationSpeed
        anim.speed = animationSpeed;

    }


    void OnAnimatorMove()
    {

        Vector3 newRootPosition;
        Quaternion newRootRotation;
       		
        newRootPosition = anim.rootPosition;
       
        //use rotational root motion as is
        newRootRotation = anim.rootRotation;

        this.transform.position = newRootPosition;
        this.transform.rotation = newRootRotation;

    }

}
