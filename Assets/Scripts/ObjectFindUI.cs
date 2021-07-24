using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectFindUI : MonoBehaviour
{
    // Start is called before the first frame update
    Text planetFindUIl;
    Transform camChange;
    void Start()
    {
        planetFindUIl = this.gameObject.GetComponent<Text>();
        planetFindUIl.color = Color.white;
        camChange = this.gameObject.GetComponentInParent<Transform>().GetComponentInParent<Transform>();
    }

    Vector3 forward;
    void Update()
    {
        forward = camChange.forward;
        
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Findable"))
        {
            //Debug.Log(forward+"mmmm"+(i.transform.position - camChange.position).normalized);

            if ((forward - (i.transform.position - camChange.position).normalized).magnitude < .1)
            {
                planetFindUIl.text = "Type: " + i.name + "\nDistance: " + Vector3.Distance(i.transform.position, GameObject.FindObjectOfType<MainBody>().gameObject.transform.position)+"\nMass: "+i.GetComponent<Rigidbody>().mass;
                break;
            }else
            {
                planetFindUIl.text = "";
            }

        }
        
        
    }
    
}
