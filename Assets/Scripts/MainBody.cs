using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBody : MonoBehaviour
{
    public float char_speed; 

    private Rigidbody rb;

    public Transform camchange;
    public float maxBurnerSpeed =50f;

    ParticleSystem emissions;
    float colorlevel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        emissions = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal"); //a,d go side to side
        float vertical = Input.GetAxis("Vertical"); //w,s go up and down

        float up = Input.GetAxis("Jump"); //a,d go side to side
        float down =-(Input.GetAxis("Fire1")); //w,s go up and down

        var color = emissions.main;
        var emissionRate = emissions.emission;
        colorlevel =rb.velocity.magnitude / maxBurnerSpeed;
        if(colorlevel < .01)
        {
            emissionRate.rateOverTime = 0;
        }
        else if(colorlevel <1)
        {
            emissionRate.rateOverTime = 25;
            color.startColor = new Color(255-colorlevel*255, 0,colorlevel * 255);
            
        }
        else 
        {
            emissionRate.rateOverTime = 25;
            color.startColor = new Color(0, 0, 255);
        }

        

        //added for rocket
        //Debug.Log(camchange.rotation);
        this.gameObject.transform.rotation = camchange.transform.rotation;
        addForce(changeView(new Vector3(horizontal,up+down,vertical),camchange));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.drag = 1;    
        }
        else
        {
            rb.drag = .05f;
        }
    }
    void LateUpdate()
    {
        if (this.gameObject.transform.position.magnitude >7000)
        {
            SceneManager.LoadScene("final", LoadSceneMode.Single);
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
        
    }
    private void addForce(Vector3 direction)
    {
        //Debug.Log(direction);
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
