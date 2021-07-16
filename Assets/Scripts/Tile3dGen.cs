using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//does not work
public class Tile3dGen : MonoBehaviour
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

    int tileHeight;
    int tileWidth;
    int tileLength;
    void Start()
    {
        Create3dTile();
    }

    // Update is called once per frame
    void Create3dTile()
    {
        Vector3[] verticies = this.tileFilter.mesh.vertices;
        tileHeight = (int)Mathf.Sqrt(verticies.Length);
        tileWidth = tileLength;
        tileWidth=tileHeight;

        //offset part

        float[,,] hmap = this.noise.Generate3dNoiseMap(tileHeight, tileWidth, tileWidth, 0.0f, 0.0f, 0.0f, 0.0f);
        
        Texture3D finalTexture = Build3dTexture(hmap);
        //CreateAsset(finalTexture, "Assets/Example3DTexture.asset");



        //Update3dVerticies(hmap);
    }
    Texture3D Build3dTexture(float[,,] noiseMap)
    {
        Texture3D tex = new Texture3D(tileHeight,tileWidth,tileLength,TextureFormat.RGBA32,1);
        Color[] map = new Color[tileHeight*tileWidth*tileLength];
        int c = 0;
        for (int i=0;i<tileLength;i++)
        {
            for (int j=0;j<tileHeight;j++)
            {
                for (int k=0;k<tileWidth;k++)
                {
                    TerrainType x = ReturnType(noiseMap[i, j, k]);
                    map[c] = x.color;
                    c++;
                }
            }
        }
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.SetPixels(map);
        tex.Apply();
        return tex;
    }

    TerrainType ReturnType(float h)
    {
        foreach (TerrainType terrain in terrainTypes)
        {
            if (h < terrain.height)
            {
                return terrain;
            }
        }
        return terrainTypes[terrainTypes.Length - 1];
    }
    private void Update3dVerticies(float[,,] noiseMap)
    {
     
    }
}
