using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    float speed = 4.0f; //how fast it shakes
    float amount = 0.1f; //how much it shakes

    void Update()
    {
        transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z);
    }

}
