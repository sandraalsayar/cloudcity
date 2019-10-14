using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // guaranteed to be run after all objects have been processd through update
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
