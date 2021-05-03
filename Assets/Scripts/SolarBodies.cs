using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarBodies : MonoBehaviour
{
    // Setting the number of planets that I want in each one
    public int planetCount;
    void Start()
    {
        for(int i = 0; i < planetCount; i++)
        {
            GameObject newPlanet = new GameObject();
            newPlanet.AddComponent<Rigidbody>();
            newPlanet.GetComponent<Rigidbody>().useGravity = false;
            newPlanet.AddComponent <Planet> ();
            newPlanet.GetComponent<Planet>().resolution = 2;
            newPlanet.GetComponent<Transform>().position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            newPlanet.AddComponent<Gravity>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
