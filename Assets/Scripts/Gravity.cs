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
        bigG =1f;
        mass = 500;
    }
    void FixedUpdate()
    {
        Gravity[] gravityField = FindObjectsOfType<Gravity>();
        foreach (Gravity g in gravityField)
        {
            if (g ==this)
            {
                continue;
            }
            Debug.Log(g.mass);
            Pull(g);
        }
    }

    void Pull(Gravity otherObject)
    {
        Rigidbody otherRb = otherObject.rb;
        Vector3 dir = otherRb.transform.position - this.transform.position;
        float r = Vector3.Distance(otherRb.transform.position, this.transform.position);
        float forceMag = (bigG * otherRb.mass * this.mass) / Mathf.Pow(r, 2);
        Vector3 force = dir.normalized * forceMag;
        Debug.Log(force);
        
        rb.AddForce(force);
        
    }   
}
