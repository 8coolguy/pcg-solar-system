using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    public bool enable;
    public float strength;
    public float rough;  
    public float minValue;
    public Vector3 center;
    [Range(1,8)]
    public int numLayers;

    public float persistance;


    
}
