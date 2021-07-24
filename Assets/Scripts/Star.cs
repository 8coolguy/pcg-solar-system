using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    //public float scale;

    public ColorSettings colors;
    public ShapeSettings shapes;
    public Material particle;
    Color starColor;
    float scale;
    bool changed;
    private void Start()
    {
        this.gameObject.tag = "Findable";
        scale = Random.Range(20f, 40f);
        shapes.radius = scale*5;
        starColor = new Color(Random.Range(.2f, 1.0f), Random.Range(.2f, 1.0f), Random.Range(.2f, 1.0f));
        colors.colorBase = starColor; 
        this.gameObject.AddComponent<Planet>();

        this.gameObject.GetComponent<Planet>().shapeSettings = shapes;
        this.gameObject.GetComponent<Planet>().colorSettings = colors;
        this.gameObject.GetComponent<Planet>().s = 1;
        this.gameObject.GetComponent<Planet>().up = true;
        this.gameObject.GetComponent<Planet>().resolution = 12;

        this.gameObject.GetComponent<Planet>().AdjustScale();
        //star.transform.parent = this.gameObject.transform;
        
        
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().mass=scale *800;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.AddComponent<Gravity>();

        this.gameObject.transform.position = new Vector3(0, 0, 0);
        CreateParticles();
        this.gameObject.name="Star";
        changed = false;
    }
    
    private void LateUpdate()

    {
        if (!changed)
        {
            this.gameObject.name = "Star";
            changed = true;
        }

    }

    void AdjustScale()
    {
        foreach (Transform face in this.gameObject.GetComponentsInChildren<Transform>())
        {
            face.localScale = new Vector3(scale, scale, scale);
        }
    }
    void CreateParticles()
    {
        this.gameObject.AddComponent<ParticleSystem>();
        //this.gameObject.AddComponent<ParticleSystemRenderer>();
        var main = this.gameObject.GetComponent<ParticleSystem>().main;
        main.maxParticles = 100;
        //main.duration = 5;
        main.loop = true;
        var life = main.startLifetime;
        life.constantMin = 35;
        life.constantMax = 100;
        main.startLifetime = life;
        var start = main.startSize;
        start.constantMin = 70;
        start.constantMax = 230;
        main.startSize = start;

        main.startSpeed = 1;
        main.startColor = starColor;

        var emission = this.gameObject.GetComponent<ParticleSystem>().emission;
        emission.rateOverTime = 25;

        var shape = this.gameObject.GetComponent<ParticleSystem>().shape;
        shape.shapeType = ParticleSystemShapeType.Sphere;
        shape.radius = scale * 5*1.5f;
        shape.sphericalDirectionAmount = 1;

        var render = this.gameObject.GetComponent<ParticleSystemRenderer>();
        render.material = particle;




    }


}
