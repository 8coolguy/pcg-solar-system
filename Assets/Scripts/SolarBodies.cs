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
            newPlanet.GetComponent<Rigidbody>().isKinematic = false;
            newPlanet.AddComponent <Planet>().s =1;
            newPlanet.GetComponent<Planet>().resolution = 16;
            newPlanet.GetComponent<Planet>().up =true;
            newPlanet.GetComponent<Planet>().colorSettings = colors;
            newPlanet.GetComponent<Planet>().shapeSettings = shape;

            int x = Random.Range(5, 15);
            newPlanet.transform.localScale = new Vector3(x, x, x);




            Vector3 pos =new Vector3(0,0,0);
            while (pos.magnitude <3000) {
                pos = new Vector3(Random.Range(-2000, 2000), Random.Range(-2000, 2000), Random.Range(-2000, 2000));
            }
            newPlanet.transform.position = pos;
            
            
            newPlanet.AddComponent<Gravity>();
            newPlanet.GetComponent<Rigidbody>().mass = x * 50;
        }
    }

    // Update is called once per frame

}
