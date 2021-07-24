using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    //canvas
    public Canvas myUi;


    public GameObject mainBody;
    public GameObject lighting;
    public GameObject mainCamera;
    
    //planets set to  1 in the script 
    
    public ColorSettings colors;
    public ShapeSettings shapes;
    //stars
    public int numOfStars = 10000;
    public int scale = 2000;
    
    //center
    public GameObject star;
    //private vars
    GameObject main;
    GameObject lights;
    GameObject cam;
    int numOfSolarBodies;
    GameObject stars;
    //GameObject star;
    
    public void Start()
    {
        //mainbody, cam, and lights
        main = Instantiate(mainBody, new Vector3(Random.Range(-500, -100), Random.Range(-500, -100), Random.Range(-500, -100)), Quaternion.identity);
        lights = Instantiate(lighting);
        cam = Instantiate(mainCamera);
        //set the main bodystuff
        main.GetComponent<MainBody>().camchange= cam.transform;
        
        cam.GetComponent<CameraMovement>().objecto = main.transform;
        cam.GetComponent<CameraMovement>().lightchange = lights.transform;


        //stars
        stars = new GameObject("Stars");
        stars.AddComponent<StarLight>();
        stars.GetComponent<StarLight>().scale = 4000;
        stars.GetComponent<StarLight>().starCount = numOfStars;


        //sun or center
        
        Instantiate(star);

        //planets
        
        numOfSolarBodies = (int)Random.Range(1, 12);
        GenerateShapeSettings();
        GenerateColorSettings();
        for (int i=0; i< numOfSolarBodies; i++)
        {
            GameObject planet = new GameObject("planet");
            planet.AddComponent<SolarBodies>();
            planet.GetComponent<SolarBodies>().colors = colors;
            planet.GetComponent<SolarBodies>().shape = shapes;
            planet.GetComponent<SolarBodies>().solarRadiusXZ = Random.Range(1000, 3000);



        }


    }
    void GenerateColorSettings()
    {
        
        if(Random.value > .8)
        {
            colors.enable = false;
            colors.colorBase = Random.ColorHSV();
        }
        else
        {
            colors.enable = true;
            int numOfColors =(int)Random.Range(1, 8);
            colors.heights = new ColorHeights[numOfColors];
            for(int i =0; i <numOfColors; i++)
            {
                if (i == 0) {
                    /*
                    var heights = colors.heights[i];
                    heights.color = Random.ColorHSV();
                    heights.height = Random.value;
                    */
                    colors.SetHeight(Random.value, 0, Random.ColorHSV());
                }
                else
                {
                    /*
                    var heights = colors.heights[i];
                    heights.color = Random.ColorHSV();
                    heights.height = Random.Range(colors.heights[i-1].height, 1);
                    */
                    colors.SetHeight(Random.Range(colors.heights[i - 1].height, 1), i, Random.ColorHSV());
                }
            }
            
           

        }
        //return colors;
    }
    void GenerateShapeSettings()
    {
        
        NoiseSettings noises = new NoiseSettings();
        noises.enable = true;
        noises.strength = Random.Range(.2f, 3);
        noises.rough= Random.Range(.5f, 5);
        noises.minValue = Random.Range(.5f, 2.5f);
        noises.persistance = Random.Range(1, 3);
        noises.numLayers = (int)Random.Range(2, 6);
        shapes.noiseSettings = noises;


        //return shapes;
    }
}
