using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLight : MonoBehaviour
{
    // Start is called before the first frame update
    public int starCount;

    void Start()
    {
        GameObject stars = this.gameObject;
        for (int i = 0; i < starCount; i++)
        {
            GameObject x=GameObject.CreatePrimitive(PrimitiveType.Sphere);// ;
            x.transform.position = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1).normalized * 3000;
            x.transform.parent = this.gameObject.transform;
            
             

        }
    }


}
