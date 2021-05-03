using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLight : MonoBehaviour
{
    // Start is called before the first frame update
    public int starCount;
    void Start()
    {
        GameObject stars = this.gameObject;
        for (int i = 0; i < starCount; i++)
        {
            GameObject newPlanet = new GameObject();
            newPlanet.AddComponent<Rigidbody>();
            newPlanet.GetComponent<Rigidbody>().useGravity = false;
            newPlanet.AddComponent<Planet>();
            newPlanet.GetComponent<Planet>().resolution = 1;
            newPlanet.GetComponent<Transform>().position = new Vector3((Random.value*2)-1, (Random.value*2)-1, (Random.value*2)-1).normalized*1000;
            newPlanet.transform.SetParent(stars.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
