using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMapGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    public float[,] GenerateNoiseMap(int mapHeight, int mapWidth, float scale, float offsetX, float offsetZ, Wave[] waves)
    {
        float[,] noiseMap = new float[mapHeight, mapWidth];

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                //change the unifrom gen to make it look better in final project
                float noise = 0.0f;
                float normal = 0.0f;
                foreach (Wave wave in waves)
                {
                    noise += wave.amplitude * Mathf.PerlinNoise(((i + offsetX) / scale) * (wave.seed + wave.frequency), ((j + offsetZ) / scale) * (wave.seed + wave.frequency));
                    normal += wave.amplitude;
                }
                noise /= normal;



                noiseMap[i, j] = noise;/*Random.Range(0, 3);*/
                // Debug.Log(Mathf.PerlinNoise(j / scale, i / scale));
                // Debug.Log(Mathf.PerlinNoise(j / scale, i / scale));

            }
        }
        //Debug.Log(mapHeight+" "+mapWidth);
        return noiseMap;
    }
    public static float Perlin3D(float x, float y, float z)
    {
        float ab = Mathf.PerlinNoise(x, y);
        float bc = Mathf.PerlinNoise(y, z);
        float ac = Mathf.PerlinNoise(x, z);

        float ba = Mathf.PerlinNoise(y, x);
        float cb = Mathf.PerlinNoise(y, z);
        float ca = Mathf.PerlinNoise(z, x);

        float abc = ab + bc + ac + ba + cb + ca;
        return abc / 6f;
    }
    public float[,,] Generate3dNoiseMap(int mapx, int mapy, int mapz, float scale, float offsetX,float offsetY,float offsetZ)
    {
        float[,,] noiseMap = new float[mapx, mapy, mapz];
        //gonna add waves later
        for (int i=0;i<mapx;i++)
        {
            for (int j=0;j<mapy;j++)
            {
                for (int k=0;k<mapz;k++)
                {
                    float noise=Perlin3D(i,j,k);
                    noiseMap[i, j, k] = noise;

                }
            }
        }
        Debug.Log(noiseMap[0, 0, 0]);
        return noiseMap;

    } 
}
    
