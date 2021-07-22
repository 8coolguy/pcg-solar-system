using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody rb;

    public float bigG;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        bigG = 100f;

    }
    void Update()
    {
        Gravity[] gravityField = FindObjectsOfType<Gravity>();
        foreach (Gravity g in gravityField)
        {
            if (g.transform.position == this.gameObject.transform.position)
            {
                continue;
            }
            //Debug.Log(g.mass);
            Pull(g.gameObject);
        }
    }

    void Pull(GameObject otherObject)
    {
        


            
            Vector3 dir =  otherObject.transform.position- this.transform.position;
            float r = Vector3.Distance(otherObject.transform.position, this.transform.position);
            float forceMag = (bigG * otherObject.GetComponent<Rigidbody>().mass * rb.mass) / (Mathf.Pow(r, 2));
            Vector3 force = dir.normalized * forceMag;
            //Debug.Log(force);
            
            if(force !=null)
                rb.AddForce(force);
            
        
    }   
}
