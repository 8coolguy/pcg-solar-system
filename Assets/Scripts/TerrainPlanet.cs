using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlanet : MonoBehaviour
{
    public float scale =1 ;

    void Start()
    {
        GameObject current = this.gameObject;
        foreach (MeshFilter i in current.GetComponentsInChildren<MeshFilter>())
        {
            Mesh mesh = i.mesh;
            // Randomly change vertices
            Vector3[] vertices = mesh.vertices;
            int p = 0;
            while (p < vertices.Length)
            {
                vertices[p] += new Vector3(0, Random.Range(-0.05F, 0.05F), 0);
                p++;
            }
            mesh.vertices = vertices;
            mesh.RecalculateNormals();
        }
    }
    
    private float[,] GenerateNoiseMap()
    {
        return null;
    }
   

    private Texture2D BuildTexture()
    {
        return null;
    }
}
