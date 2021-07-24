using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarBodies : MonoBehaviour
{
    // Setting the number of planets that I want in each one
    int planetCount = 1;
    public ShapeSettings shape;
    public ColorSettings colors;
    [Range(1000,5000)]
    public float solarRadiusXZ;
    GameObject newPlanet;
    float greatestMass;

    int x;

    void Start()
    {
        for(int i = 0; i < planetCount; i++)
        {


            shape.noiseSettings.center = transform.position;
            x = Random.Range(15, 20);
            shape.radius = x;
            //setting up the new planet
            newPlanet = new GameObject();
            newPlanet.transform.parent = this.gameObject.transform;
            

            newPlanet.AddComponent<Rigidbody>();
            newPlanet.GetComponent<Rigidbody>().useGravity = false;
            newPlanet.GetComponent<Rigidbody>().isKinematic = false;
            newPlanet.GetComponent<Rigidbody>().mass = x * 10;
            //settign the shape
            newPlanet.AddComponent <Planet>().s =1;
            newPlanet.GetComponent<Planet>().resolution = 12;
            newPlanet.GetComponent<Planet>().up =true;
            newPlanet.GetComponent<Planet>().colorSettings = colors;
            newPlanet.GetComponent<Planet>().shapeSettings = shape;
            
            //setting a random position

            
            newPlanet.AddComponent<Gravity>();
            //SetPos();


            //need to calculate the initial velocity for the body will only really account for the largest gravity
            //myb ill try to account for all the objs

            Invoke("SetPos", .01f);
            Invoke("SetV0", .02f);
            

        }
        
    }
    void SetPos()
    {
        //settign the pos
        Vector3 pos = new Vector3(Random.Range(-5000, 5000), /*Random.Range(-2000, 2000)*/0, Random.Range(-5000, 5000));
        while (pos.magnitude < solarRadiusXZ)
        {
            pos = new Vector3(Random.Range(-5000, 5000), /*Random.Range(-2000, 2000)*/0, Random.Range(-5000, 5000));
        }
        newPlanet.transform.position = pos;
    }
    void SetV0()
    {
        Gravity star=newPlanet.gameObject.GetComponent<Gravity>();
        Vector3 position;
        Vector3 v0;
        Vector3 dir;
        Gravity[] gravityField = FindObjectsOfType<Gravity>();
        greatestMass = 0;
        foreach (Gravity g in gravityField)
        {
            if (g.gameObject.GetComponent<Rigidbody>().mass > greatestMass)
            {
                star = g;
                greatestMass = g.gameObject.GetComponent<Rigidbody>().mass;
            }
        }
        //Debug.Log(newPlanet.transform.position);
        position = star.gameObject.transform.position - newPlanet.transform.position;
        dir = Vector3.Cross(Vector3.up, position).normalized;

        v0 = dir * Mathf.Pow((star.bigG * star.gameObject.GetComponent<Rigidbody>().mass) / (position.magnitude), .5f);
        //Debug.Log(position.magnitude);
        newPlanet.GetComponent<Rigidbody>().velocity = v0;
    }

}
