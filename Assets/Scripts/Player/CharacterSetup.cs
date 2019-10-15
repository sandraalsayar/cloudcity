using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSetup : MonoBehaviour
{

    //public CharacterInputController[] ControllableCharacters = { };
    public GameObject player;
    public ThirdPersonCamera thirdPersonCamera;

    public string CameraPositionMarkerName = "CamPos";

    void Start()
    {
        if (thirdPersonCamera == null)
        {
                Debug.LogError("camera must be set");
        }
            thirdPersonCamera.desiredPose = player.transform.Find(CameraPositionMarkerName);
    }

}
