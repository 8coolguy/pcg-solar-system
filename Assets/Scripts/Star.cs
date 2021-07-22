using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    //public float scale;

    public ColorSettings colors;
    public ShapeSettings shapes;
    float scale;
    private void Start()
    {
        scale = Random.Range(15f, 20f);
        shapes.radius = scale;
        colors.colorBase = new Color(Random.Range(.2f, 1.0f), Random.Range(.2f, 1.0f), Random.Range(.2f, 1.0f));
        this.gameObject.AddComponent<Planet>();

        this.gameObject.GetComponent<Planet>().shapeSettings = shapes;
        this.gameObject.GetComponent<Planet>().colorSettings = colors;
        this.gameObject.GetComponent<Planet>().s = 1;
        this.gameObject.GetComponent<Planet>().up = true;
        this.gameObject.GetComponent<Planet>().resolution = 4;

        this.gameObject.GetComponent<Planet>().AdjustScale();
        //star.transform.parent = this.gameObject.transform;
        
        
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().mass=scale *500;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.AddComponent<Gravity>();

        this.gameObject.transform.position = new Vector3(0, 0, 0);
        
    }
 

    void AdjustScale()
    {
        foreach (Transform face in this.gameObject.GetComponentsInChildren<Transform>())
        {
            face.localScale = new Vector3(scale, scale, scale);
        }
    }


}
