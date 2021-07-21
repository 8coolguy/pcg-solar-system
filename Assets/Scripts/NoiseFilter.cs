using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{

    NoiseSettings settings;
    Noise noise = new Noise();
    public NoiseFilter(NoiseSettings settings)
    {
        this.settings = settings;
    }


    public float CalculateNoise(Vector3 point)
    {
        if (settings.enable)
        {
            float frequency = 1f;
            float a = 1f;
            float noiseVal = 0;
            for (int i = 0; i < settings.numLayers; i++)
            {
                float v = noise.Evaluate(point + settings.center);
                noiseVal += (v + 1) * .5f;
                frequency *= settings.rough;
                a *= settings.persistance;
            }


            noiseVal = Mathf.Max(0, noiseVal - settings.minValue);
            return noiseVal * settings.strength;
        }
        return 0;
    }
}
