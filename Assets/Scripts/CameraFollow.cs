using System.Collections;
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

    //new
    [SerializeField]
    private Vector3 offset = new Vector3(0f,3f,0f);
    private Vector3 lookDir;
    private Vector3 velocityCamSmooth = Vector3.zero;
    [SerializeField]
    private float camSmoothDampTime=0.1f;


    //newnew
    private Vector3 curLookDir;
    private Vector3 velocityLookDir=Vector3.zero;
    [SerializeField]
    private float lookDirDampTime=0.1f;
    private CharacterInputController follower;

    void Start(){
        follower = GameObject.FindWithTag("Player").GetComponent<CharacterInputController>();
        follow = GameObject.FindWithTag("camera").transform;

        lookDir = follow.forward;
        curLookDir = follow.forward;
    }
    void LateUpdate(){

        float leftX = Input.GetAxis("Horizontal");
        float leftY = Input.GetAxis("Vertical");
        Vector3 characterOffset = follow.position + offset;

        //new for polish
        if(follower.Speed > follower.LocomotionThreshold){
            //Debug.Log("turn cam");
            lookDir = Vector3.Lerp(follow.right * (leftX<0?1f:-1f),follow.forward*(leftY<0?-1f:1f),Mathf.Abs(Vector3.Dot(this.transform.forward,follow.forward)));
            curLookDir = Vector3.Normalize(characterOffset-this.transform.position);
            curLookDir.y = 0;
            curLookDir = Vector3.SmoothDamp(curLookDir, lookDir, ref velocityLookDir, lookDirDampTime);
        }
        targetPosition = characterOffset + follow.up * distanceUp - Vector3.Normalize(curLookDir) * distanceAway;

        //transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*smooth);
        CollisionWall(characterOffset,ref targetPosition);
        smoothPosition(this.transform.position,targetPosition);
        transform.LookAt(follow);
    }

    public void smoothPosition(Vector3 fromPos, Vector3 toPos){
        this.transform.position = Vector3.SmoothDamp(fromPos,toPos,ref velocityCamSmooth,camSmoothDampTime);
    }

    //handles camera changing position when it hits a wall
    private void CollisionWall(Vector3 fromObject, ref Vector3 toTarget){
        Debug.DrawLine(fromObject, toTarget, Color.cyan);
        RaycastHit wallHit = new RaycastHit();
        if(Physics.Linecast(fromObject, toTarget,out wallHit)){
            Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x,toTarget.y,wallHit.point.z);
        }
    }
}
