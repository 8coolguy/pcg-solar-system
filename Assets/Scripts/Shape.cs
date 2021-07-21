using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape 
{
    ShapeSettings settings;
    NoiseFilter noiseFilter;
    public Shape(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter(settings.noiseSettings);
    }

    public Vector3 AdjustPlanetVectors(Vector3 point)
    {
        return point*settings.radius*(1+noiseFilter.CalculateNoise(point));
    }
}
