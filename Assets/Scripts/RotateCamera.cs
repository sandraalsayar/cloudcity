using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 15.0f;
    private const float Y_ANGLE_MAX = 25.0f;

    public Transform character;

    private float dist = -5.0f;
    private float curX = 0.0f;
    private float curY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetAxis("Mouse X") != null || Input.GetAxis("Mouse Y") != null){
            curX += Input.GetAxis("Mouse X");
            curY += Input.GetAxis("Mouse Y");
        }
        curY = Mathf.Clamp(curY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }
    void LateUpdate()
    {
        gameObject.transform.position = character.position + Quaternion.Euler(curY,curX,0)*new Vector3(0,0,dist);
        gameObject.transform.LookAt(character.position);

        //look @other direction
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.Rotate(new Vector3(0.0f, 180f, 0.0f));
        }
    }
    //void LateUpdate()
    //{
    //    if(Input.GetKey(KeyCode.Space)){
    //        transform.Rotate(new Vector3(0.0f, 180f, 0.0f));
    //    }
    //}


}
