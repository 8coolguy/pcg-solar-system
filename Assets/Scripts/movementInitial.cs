using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementInitial : MonoBehaviour
{

    // Start is called before the first frame update

    Rigidbody rb;
    
    public Vector3 speed;


    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
