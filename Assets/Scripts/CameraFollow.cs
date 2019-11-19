﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Transform follow;
    private Vector3 targetPosition;

    void Start(){
        follow = GameObject.FindWithTag("camera").transform;
    }
    void LateUpdate(){
        targetPosition = follow.position + follow.up * distanceUp - (follow.forward * distanceAway);
        //Debug.DrawRay();
        //Debug.DrawRay();
        //Debug.Line();

        transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*smooth);

        transform.LookAt(follow);
    }
    //public Transform cameraTarget;
    //public float sSpeed = 10.0f;
    //public Vector3 dist;
    //public Transform lookTarget;

    //void FixedUpdate(){
    //    Vector3 dPos = cameraTarget.position + dist;
    //    Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
    //    transform.position = sPos;
    //    transform.LookAt(lookTarget.position);
    //}
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
