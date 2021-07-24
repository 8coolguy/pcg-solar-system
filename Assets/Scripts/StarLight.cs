using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLight : MonoBehaviour
{
    // Start is called before the first frame update
    public int starCount;
    [Range(1000,8000)]
    public float scale;
    void Start()
    {
        GameObject stars = this.gameObject;
        for (int i = 0; i < starCount; i++)
        {
            GameObject x=GameObject.CreatePrimitive(PrimitiveType.Sphere);// ;
            x.transform.position = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1).normalized * scale;
            x.transform.parent = this.gameObject.transform;
            
             

        }
    }


}
