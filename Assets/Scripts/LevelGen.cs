using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    // Start is called before the first frame update

    public int tilenumHeight;
    public int tilenumWidth;
    public GameObject replicatedPlane;
   
    void Start()
    {
        float h = replicatedPlane.GetComponent<MeshRenderer>().bounds.size.z;
        float w = replicatedPlane.GetComponent<MeshRenderer>().bounds.size.x;
        
        for(int i = 0; i < tilenumHeight; i++)
        {
            for(int j=0; j < tilenumWidth; j++)
            {
                //transform.position =transform.position+ new Vector3;
                //Transform pos = transform.position + newLocation;
                GameObject x = Instantiate(replicatedPlane, new Vector3(i * w, 0, h * j), Quaternion.identity); ;
                x.transform.SetParent(this.gameObject.transform);
            }
        }
    }

    
   
}
