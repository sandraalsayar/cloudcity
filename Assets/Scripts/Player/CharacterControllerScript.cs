﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

//require some things the bot control needs
[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
[RequireComponent(typeof(CharacterInputController))]
public class CharacterControllerScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rbody;
    private CharacterInputController cinput;

    //private Transform leftFoot;
    //private Transform rightFoot;

    ////Useful if you implement jump in the future...
    public float jumpableGroundNormalMaxAngle = 45f;
    public bool closeToJumpableGround;

    private int groundContactCount = 0;

    //// public vars
    //public float animationSpeed = 1.1f;
    public float animationSpeed = 0.5f;
    public float rootMovementSpeed = 1.4f;
    public float rootTurnSpeed = 2f;
    //public GameObject buttonObject;

    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }

    void Awake()
    {

        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.Log("Animator could not be found");

        rbody = GetComponent<Rigidbody>();

        if (rbody == null)
            Debug.Log("Rigid body could not be found");

        cinput = GetComponent<CharacterInputController>();
        if (cinput == null)
            Debug.Log("CharacterInput could not be found");
    }


    //// Use this for initialization
    void Start()
    {
    //    //example of how to get access to certain limbs
    //    leftFoot = this.transform.Find("mixamorig:Hips/mixamorig:LeftUpLeg/mixamorig:LeftLeg/mixamorig:LeftFoot");
    //    rightFoot = this.transform.Find("mixamorig:Hips/mixamorig:RightUpLeg/mixamorig:RightLeg/mixamorig:RightFoot");

    //    if (leftFoot == null || rightFoot == null)
    //        Debug.Log("One of the feet could not be found");

    }






    void Update()
    {

        float inputForward = 0f;
        float inputTurn = 0f;
        bool inputAction = false;
    //    // input is polled in the Update() step, not FixedUpdate()
    //    // Therefore, you should ONLY use input state that is NOT event-based in FixedUpdate()
    //    // Input events should be handled in Update(), and possibly passed on to FixedUpdate() through 
    //    // the state of the MonoBehavior
        if (cinput.enabled)
        {
            //Debug.Log("input enabled, moving");
            inputForward = cinput.Forward;
            inputTurn = cinput.Turn;
            inputAction = cinput.Action;

        }

    //    //onCollisionXXX() doesn't always work for checking if the character is grounded from a playability perspective
    //    //Uneven terrain can cause the player to become technically airborne, but so close the player thinks they're touching ground.
    //    //Therefore, an additional raycast approach is used to check for close ground
        bool isGrounded = IsGrounded;
        //|| CharacterCommon.CheckGroundNear(this.transform.position, jumpableGroundNormalMaxAngle, 0.1f, 1f, out closeToJumpableGround);

    //    //set anim component speed to speedscalar
    //    //between 1f regular speed, 0.5f half, 2f twice as fast
        anim.speed = animationSpeed;

        anim.SetFloat("velx", inputTurn);
        anim.SetFloat("vely", inputForward);
        //anim.SetBool("isFalling", !isGrounded);
    //    anim.SetBool("doButtonPress", inputAction);

        //if (inputAction)
            //Debug.Log("Action pressed");

    }


    ////This is a physics callback
    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.tag == "Ground")
        {

            ++groundContactCount;

            // Generate an event that might play a sound, generate a particle effect, etc.
            //EventManager.TriggerEvent<PlayerLandsEvent, Vector3, float>(collision.contacts[0].point, collision.impulse.magnitude);

        }

    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.gameObject.tag == "Ground")
        {
            --groundContactCount;
        }

    }

    void OnAnimatorMove()
    {

        Vector3 newRootPosition;
        Quaternion newRootRotation;

        bool isGrounded = IsGrounded;
            //|| CharacterCommon.CheckGroundNear(this.transform.position, jumpableGroundNormalMaxAngle, 0.1f, 1f, out closeToJumpableGround);

        if (isGrounded)
        {
            //use root motion as is if on the ground        
            newRootPosition = anim.rootPosition;
        }
        else
        {
            //Simple trick to keep model from climbing other rigidbodies that aren't the ground
            newRootPosition = new Vector3(anim.rootPosition.x, this.transform.position.y, anim.rootPosition.z);
        }

    //    //use rotational root motion as is
        newRootRotation = anim.rootRotation;

    //    //TODO Here, you could scale the difference in position and rotation to make the character go faster or slower

        //this.transform.position = newRootPosition;
        //this.transform.rotation = newRootRotation;
        this.transform.position = Vector3.LerpUnclamped(this.transform.position, new Vector3(anim.rootPosition.x, this.transform.position.y, anim.rootPosition.z), rootMovementSpeed);
        this.transform.rotation = Quaternion.LerpUnclamped(this.transform.rotation, anim.rootRotation, rootTurnSpeed);

    }

    //void OnAnimatorIK()
    //{
    //    if(anim){
    //        AnimatorStateInfo aState = anim.GetCurrentAnimatorStateInfo(0);

    //        if(aState.IsName("ButtonPress")) {
    //            float buttonWeight = anim.GetFloat("buttonClose");

    //            // Set the look target position, if one has been assigned
    //            if(buttonObject != null) {
    //                anim.SetLookAtWeight(buttonWeight);
    //                anim.SetLookAtPosition(buttonObject.transform.position);
    //                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, buttonWeight);
    //                anim.SetIKPosition(AvatarIKGoal.RightHand, buttonObject.transform.position);
    //            }
    //        } else{
    //            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
    //            anim.SetLookAtWeight(0);
    //        }

    //    }
    //}
}