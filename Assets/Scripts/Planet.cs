using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(4,16)]
    public int resolution;
    Vector3[] dirs = {Vector3.up, Vector3.down,Vector3.forward,Vector3.back,Vector3.left,Vector3.right};
    public float scale;
    void Start()
    {
        Init();
        
    }
    private void OnValidate()
    {
        AdjustScale();
    }

    void Init()
    {
        //GameObject[] planes = new GameObject[6];

        for(int i=0;i<6; i++)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Destroy(temp.GetComponent<MeshCollider>());

            temp.transform.parent = this.transform;
            // i have to change scale here if I want to do that 
            CreateMesh(i,temp,resolution);
            
            
            
        }

    }
    //creates pretty good faces
    //learned how to create the mesh from sebastian lague tutorial
    void CreateMesh(int index,GameObject plane,int resolution)
    {
        Vector3[] verts = new Vector3[resolution * resolution];
        int[] tris = new int[(resolution - 1) * (resolution - 1) * 6];

        int triIndex = 0;

        Vector3 v1 = new Vector3(dirs[index].y, dirs[index].z, dirs[index].x);
        Vector3 v2 = Vector3.Cross(dirs[index], v1);
        for (int x = 0; x < resolution; x++)
        {
            for(int y = 0; y < resolution; y++)
            {
                int v = x*resolution + y;


                Vector2 p = new Vector2(x, y) / (resolution - 1);
                Vector3 temp = dirs[index] + (p.x - .5f) * 2 * v1 + (p.y - .5f) * 2 * v2;
                verts[v] = temp.normalized;
                
                if (x!=resolution-1 && y!=resolution-1)
                {
                    tris[triIndex]=v;
                    tris[triIndex+1]=v+resolution;
                    tris[triIndex+2]=v+1;
                    
                    
                    tris[triIndex+3]=v+1;
                    tris[triIndex+4]=v+resolution;
                    tris[triIndex + 5]=v+resolution+1;
                    triIndex += 6;
                    
                }
                


            }
        }
        
        //Debug.Log(tris);
        plane.GetComponent<MeshFilter>().mesh.Clear();
        plane.GetComponent<MeshFilter>().mesh.vertices = verts;
        plane.GetComponent<MeshFilter>().mesh.triangles = tris;
        plane.GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }
    void AdjustScale()
    {
        this.gameObject.transform.localScale = new Vector3(scale, scale, scale); ;
    }
}
