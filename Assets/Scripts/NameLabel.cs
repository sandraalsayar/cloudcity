using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameLabel : MonoBehaviour
{
    public Text buildingLabel;

    // Update is called once per frame
    void Update()
    {
        //world point => screen point
        //looking for tag maincamera
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        buildingLabel.transform.position = namePos;
    }
}
