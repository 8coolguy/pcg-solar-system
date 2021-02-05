using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
//The goal here is to create a octosphere
public class Sphere : MonoBehaviour
{
    /*private void OnValidate()
    {
        Initialize();
    }
    */
    [Range(1,7)]
    public int levels =1;
    [Range(1, 64)]
    public float radius = 1f;
    void Awake()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        gameObject.GetComponent<MeshFilter>().mesh = Octasphere.Create(levels,radius);
    }
}

    
