using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour
{
    ColorSettings settings;

    public Colour(ColorSettings settings)
    {
        this.settings = settings;
    }
    public bool Enabled()
    {
        return settings.enable;
    }

    public Color SetPlanetColor()
    {
        return settings.colorBase;
    }
    public Texture2D GetColorHeights(int res,float[] heights)
    {
        Texture2D tex = new Texture2D(res,res);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;
        
        
         for(int x = 0; x < res; x++)
         {
            for (int y = 0; y < res; y++)
            {
                //tex.SetPixel(x, y, Random.ColorHSV());
                Color temp=settings.colorBase;
                int j = x * res + y;
                //Debug.Log(heights[j]);
                for (int i = 0; i < settings.heights.Length; i++)
                {

                    if (heights[j] >= settings.heights[i].height)
                    {
                        
                        temp = settings.heights[i].color;
                        
                    }
                }
                tex.SetPixel(x, y, temp);

                
                //Debug.Log();
            }
         }
            
        
        
        
        tex.Apply();
        
        return tex;
    }
}
