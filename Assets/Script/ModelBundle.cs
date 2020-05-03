using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModelBundle  
{
    public Texture2D backgroundCube;
    public Texture2D groundCube;
    public GameObject latterAsset;
    public Vector3 latterPostion=Vector3.zero;
    public GameObject teacherAsset;
    public Vector3 teacherPostion= Vector3.zero;
    public GameObject objectAsset;
 
    public Vector3 objectPostion= Vector3.zero;
    public float objectSize;
    public AudioClip audioClip;
    

     
}
