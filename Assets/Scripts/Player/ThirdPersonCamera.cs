//using UnityEngine;
//using System.Collections;

//public class ThirdPersonCamera : MonoBehaviour
//{
//    public Transform PlayerTransform;

//    private Vector3 _cameraOffset;

//    [Range(0.01f, 1.0f)]
//    public float SmoothFactor = 0.5f;

//    void Start(){
//        _cameraOffset= transform.position - PlayerTransform.position;
//    }

//    void LateUpdate(){
//        Vector3 newPos = PlayerTransform.position + _cameraOffset;

//        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

//    }
//}

using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
    public float smoothTime = 1f;       // a public variable to adjust smoothing of camera motion
    public float maxSpeed = 50f;        //max speed camera can move
    public Transform desiredPose;           // the desired pose for the camera, specified by a transform in the game

    protected Vector3 currentPositionCorrectionVelocity;
    protected Vector3 currentFacingCorrectionVelocity;


    void LateUpdate()
    {

        if (desiredPose != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, desiredPose.position, ref currentPositionCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
            transform.forward = Vector3.SmoothDamp(transform.forward, desiredPose.forward, ref currentFacingCorrectionVelocity, smoothTime, maxSpeed, Time.deltaTime);
        }
    }

}