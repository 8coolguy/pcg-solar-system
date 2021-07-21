using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBody : MonoBehaviour
{
    public float char_speed;

    private Rigidbody rb;

    public Transform camchange;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal"); //a,d go side to side
        float vertical = Input.GetAxis("Vertical"); //w,s go up and down

        float up = Input.GetAxis("Jump"); //a,d go side to side
        float down =-(Input.GetAxis("Fire1")); //w,s go up and down

        addForce(changeView(new Vector3(horizontal,up+down,vertical),camchange));
        Debug.Log(this.gameObject.GetComponent<Rigidbody>().velocity);
    }
    private void addForce(Vector3 direction)
    {
        rb.AddForce(char_speed * direction);
    }


    private Vector3 changeView(Vector3 movement,Transform cam)
    {
        if (cam != null)
        {
            Vector3 dir = cam.TransformDirection(movement);
            // dir.Set(dir.x, dir.y,dir.z);
            return dir.normalized * movement.magnitude;

        }
        return movement;
    }
}
