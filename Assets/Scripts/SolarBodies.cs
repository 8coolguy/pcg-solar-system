using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarBodies : MonoBehaviour
{
    // Setting the number of planets that I want in each one
    public int planetCount;
    public ShapeSettings shape;
    public ColorSettings colors;
    void Start()
    {
        for(int i = 0; i < planetCount; i++)
        {
            shape.noiseSettings.center = transform.position;
            GameObject newPlanet = new GameObject();
            newPlanet.AddComponent<Rigidbody>();
            newPlanet.GetComponent<Rigidbody>().useGravity = false;
            newPlanet.GetComponent<Rigidbody>().isKinematic = true;
            newPlanet.AddComponent <Planet>().s =10;
            newPlanet.GetComponent<Planet>().resolution = 8;
            newPlanet.GetComponent<Planet>().up =true;
            newPlanet.GetComponent<Planet>().colorSettings = colors;
            newPlanet.GetComponent<Planet>().shapeSettings = shape;










            newPlanet.GetComponent<Transform>().position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            int x = Random.Range(10, 100);
            newPlanet.GetComponent<Transform>().localScale = new Vector3(x, x,x);
            newPlanet.AddComponent<Gravity>();
        }
    }

    // Update is called once per frame
    void Update()   
    {
        
    }
}
