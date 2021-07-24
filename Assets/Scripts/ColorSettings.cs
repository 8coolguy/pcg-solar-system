using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ColorSettings :ScriptableObject
{


    public bool enable;
    public UnityEngine.Color colorBase;

    public ColorHeights[] heights;

    public void SetHeight(float height, int index, Color colorHeight)
    {
        ColorHeights temp = new ColorHeights();
        temp.height = height;
        temp.color = colorHeight;
        heights[index] = temp;
            
    }
 

}

