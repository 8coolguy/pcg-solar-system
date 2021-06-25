using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    public float[,] GenerateNoiseMap(int mapHeight, int mapWidth, float scale,float offsetX,float offsetZ)
    {
        float[,] noiseMap =new float[mapHeight, mapWidth];

        for (int i =0;i<mapHeight; i++)
        {
            for (int j=0;j<mapWidth;j++)
            {
                noiseMap[i, j] = /*Random.Range(0, 3);*/Mathf.PerlinNoise((i+offsetX) / scale, (j+offsetZ) / scale);
                // Debug.Log(Mathf.PerlinNoise(j / scale, i / scale));
                // Debug.Log(Mathf.PerlinNoise(j / scale, i / scale));

            }
        }
        //Debug.Log(mapHeight+" "+mapWidth);
        return noiseMap;
    }
}
