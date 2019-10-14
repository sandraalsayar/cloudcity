using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //Transform cam;

    //float speed = 10f;
    //float turnspeed = 100;

    //Rigidbody rb;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    cam = Camera.main.transform;
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //applies to camera's x and z values
    //    Vector3 dir = (cam.right * Input.GetAxis("Horizontal") + (cam.forward) * Input.GetAxis("Vertical"));
    //    dir.y = 0;
    //    //player input, rotate to new position
    //    if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0){
    //        //makes player turn in correct direction
    //        rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnspeed * Time.deltaTime);
    //        rb.velocity = transform.forward*speed; //always moving forward

    //    } else{
    //        //idle
    //    }
    //}
    public bool InputMapToCircular = true;

    public float speed;
    public float jumpForce;
    //public Vector3 movement;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    //called before performing any physics calculations
    void FixedUpdate()
    {
        //need to add check that it's on the ground before jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector3(0.0f,10.0f,0.0f) * jumpForce);
        }
            


        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Vector3 movement = new Vector3(0, 0, moveVertical);
        ////Transform.rotation = Quaternion.LookAt(movement);
        ////if (movement != Vector3.zero)
        ////{
        //////    //third value is rotation speed
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveHorizontal,0,0)), 0.2f);
        ////}
        /// 

        //z axis is forward/back

        transform.Translate(new Vector3(0.0f,0.0f,moveVertical) * speed * Time.deltaTime);

        //xaxis is for rotation (always moving forward, use L/R to change direction)
        transform.Rotate(0.0f, moveHorizontal, 0.0f); 
    }

}
