using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2,256)]
    public int resolution = 4;
    Vector3[] dirs = { Vector3.up, Vector3.down, Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
    public float s = 1;
    

    public bool up;


    public ShapeSettings shapeSettings;
    public ColorSettings colorSettings;
    
    
    //variables needed for the planet
    Material m;
    Shape shapeGenerator;
    Colour colorGen;
    GameObject[] faces;
    float[,] heights;


    private void Start()
    {
        GeneratePlanet();
    }
    public void AdjustPos(Vector3 pos)
    {
        foreach (Transform face in this.gameObject.GetComponentsInChildren<Transform>())
        {
            face.localPosition = pos;
        }
    }



    void Initialize()
    {
        shapeGenerator = new Shape(shapeSettings);
        colorGen = new Colour(colorSettings);
        faces = new GameObject[6];
        heights = new float[6, resolution * resolution];



        for (int i = 0; i < 6; i++)
        {
            GameObject temp = new GameObject();

            
            temp.AddComponent<MeshFilter>();
            temp.AddComponent<MeshCollider>();
            temp.AddComponent<MeshRenderer>();


            temp.transform.parent = this.transform;
            // i have to change scale here if I want to do that 
            CreateMesh(shapeGenerator,i, temp, resolution);
            temp.GetComponent<MeshCollider>().convex = true;
            faces[i] = temp;


        }
        AdjustScale();
    }
    //creates pretty good faces
    //learned how to create the mesh from sebastian lague tutorial
    //need to find a way adjust every res of the sphere do it after the noise.
    void CreateMesh(Shape shape,int index, GameObject plane, int resolution)
    {
        Vector3[] verts = new Vector3[resolution * resolution];
        Vector2[] uvs = new Vector2[resolution * resolution];
        

        int[] tris = new int[(resolution - 1) * (resolution - 1) * 6];

        int triIndex = 0;

        Vector3 v1 = new Vector3(dirs[index].y, dirs[index].z, dirs[index].x);
        Vector3 v2 = Vector3.Cross(dirs[index], v1);
        
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                int v = x * resolution + y;


                Vector2 p = new Vector2(x, y) / (resolution - 1);
                Vector3 temp = (dirs[index] + (p.x - .5f) * 2 * v1 + (p.y - .5f) * 2 * v2).normalized;
                verts[v] = shapeGenerator.AdjustPlanetVectors(temp);
                
                uvs[v] = p;
                heights[index,v] = (verts[v]).magnitude;
                //Debug.Log(index+" ggg"+heights[index, v]);
                

                if (x != resolution - 1 && y != resolution - 1)
                {
                    tris[triIndex] = v;
                    tris[triIndex + 1] = v + resolution;
                    tris[triIndex + 2] = v + 1;


                    tris[triIndex + 3] = v + 1;
                    tris[triIndex + 4] = v + resolution;
                    tris[triIndex + 5] = v + resolution + 1;
                    triIndex += 6;

                }



            }
        }

        //Debug.Log(tris);
        Mesh mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = tris;
        mesh.uv = uvs;

        mesh.RecalculateNormals();


        plane.GetComponent<MeshFilter>().mesh.Clear();
        plane.GetComponent<MeshFilter>().mesh = mesh;
        plane.GetComponent<MeshCollider>().sharedMesh = mesh;


        plane.GetComponent<MeshRenderer>().material.color = colorGen.SetPlanetColor();

    }
    public void AdjustScale()
    {
        foreach(Transform face in this.gameObject.GetComponentsInChildren<Transform>())
        {
            face.localScale = new Vector3(s, s, s);
        }
        
    }
    public void GeneratePlanet()
    {
        Initialize();
        if (colorGen.Enabled())
        {
            GenerateColors();
            //AdjustScale();
        }
        

    }

    public void GenerateColors()
    {
        for(int f =0;f<faces.Length; f++)
        {
            

            float[] faceHeights = new float[resolution*resolution];
            float maxHeight;
            for(int x =0; x < resolution * resolution; x++)
            {
                faceHeights[x] =heights[f, x];
                //Debug.Log(f+"///"+faceHeights[x]);
            }
            maxHeight =faceHeights.Max();
            //Debug.Log(maxHeight);
            for (int x = 0; x < resolution * resolution; x++)
            {
                if (faceHeights[x] != 0) 
                    faceHeights[x] = faceHeights[x]/maxHeight;
                //Debug.Log(f+"///"+faceHeights[x]);
                

            }
            Texture2D tex = colorGen.GetColorHeights(resolution, faceHeights);
            


            faces[f].GetComponent<MeshRenderer>().material.mainTexture = tex;
          
        }
    }

}
