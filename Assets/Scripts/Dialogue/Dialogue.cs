using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to be able to edit it
[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(1,2)]
    public string[] sentences;
    public bool isCluster; //override for clusters
}
