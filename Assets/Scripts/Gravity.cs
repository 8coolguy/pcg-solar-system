using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody rb;
    public float mass;
    public float bigG;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        bigG =.01f;
        mass = 1000;
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
        if (otherObject.transform.position !=this.transform.position)
        {


            
            Vector3 dir = otherObject.transform.position - this.transform.position;
            float r = Vector3.Distance(otherObject.transform.position, this.transform.position);
            float forceMag = (bigG * otherObject.GetComponent<Gravity>().mass * this.mass) / Mathf.Pow(r, 2);
            Vector3 force = dir.normalized * forceMag;
            //Debug.Log(otherObject.transform.position+",,,,,,"+this.transform.position);
            
            if(force !=null)
                rb.AddForce(force);
            
        }
    }   
}
