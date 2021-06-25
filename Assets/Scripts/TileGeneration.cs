using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TerrainType[] terrainTypes;

    [SerializeField]
    private MeshRenderer tileRender;

    [SerializeField]
    private MeshFilter tileFilter;

    [SerializeField]
    private MeshCollider tileCollider;

    [SerializeField]
    private NoiseMapGeneration noise;

    [SerializeField]
    private float heightMultiplayer;

    [SerializeField]
    private AnimationCurve heightCurve;

    public float mapScale;

    private int tileWidth;
    private int tileHeight;
    void Start()
    {
        //tileHeight = (int)(GetComponent<MeshRenderer>().bounds.max.z - GetComponent<MeshRenderer>().bounds.min.z);
        //tileWidth = (int)(GetComponent<MeshRenderer>().bounds.max.x- GetComponent<MeshRenderer>().bounds.min.x);
        

       
        CreateTile();
    }

    // Update is called once per frame
    void CreateTile()
    {
        Vector3[] meshVertices = this.tileFilter.mesh.vertices;
        tileHeight = (int)Mathf.Sqrt(meshVertices.Length);
        tileWidth = tileHeight;

        float offsetZ=-this.gameObject.transform.position.x;
        float offsetX= -this.gameObject.transform.position.z;

        float[,] hmap = this.noise.GenerateNoiseMap(tileHeight,tileWidth,4,offsetX,offsetZ);

        Texture2D finalTexture = BuildTexture(hmap);
        this.tileRender.material.mainTexture = finalTexture;


        UpdateVerticies(hmap);
    }
    private Texture2D BuildTexture(float[,] noiseMap)
    {

        Texture2D tex = new Texture2D(tileHeight, tileWidth);
        //color map to assign each tile 
        Color[] cmap = new Color[tileHeight * tileWidth];
        int c = 0;
        for(int i = 0; i < tileHeight; i++)
        {
            for (int j =0; j < tileWidth; j++)
            {
                
                // Debug.Log(cmap[c]);
                TerrainType terrain = ReturnType(noiseMap[i, j]);
                cmap[c] = terrain.color;
                c++;
            }
        }
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.SetPixels(cmap);
        tex.Apply();
        return tex;
    }
    TerrainType ReturnType(float h)
    {
        foreach(TerrainType terrain in terrainTypes)
        {
            if (h < terrain.height)
            {
                return terrain;
            }
        }
        return terrainTypes[terrainTypes.Length - 1];
    }
    private void UpdateVerticies(float[,] noiseMap)
    {
        Vector3[] meshVertices = this.tileFilter.mesh.vertices;
        int c = 0;
        for (int i =0;i<tileHeight;i++)
        {
            for (int j =0; j<tileWidth;j++)
            {
                Vector3 newVerticie = meshVertices[c];
                meshVertices[c] = new Vector3(newVerticie.x, this.heightCurve.Evaluate(noiseMap[i,j]) * heightMultiplayer, newVerticie.z);
                c++;
            }
        }
        this.tileFilter.mesh.vertices = meshVertices;
        this.tileFilter.mesh.RecalculateBounds();
        this.tileFilter.mesh.RecalculateNormals();

        this.tileCollider.sharedMesh = this.tileFilter.mesh;
    }
}
