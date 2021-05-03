using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octasphere
{
    private static Vector3[] directions = { Vector3.left,Vector3.back,Vector3.right,Vector3.forward };
    public static Mesh Create(int level =1,float radius =1.0f)
    {
        int res = 1 << level;
        Vector3[] vertices = new Vector3[4 * ((res + 1) * (res + 1))-(6*res-3)];
        int[] triangles = new int[(1 << (level * 2 + 3)) * 3];
        CreateOctahedron(vertices, triangles, res);
        Vector3[] normals = new Vector3[vertices.Length];


        for (int i = 0; i < vertices.Length; i++)
        {

            normals[i] = vertices[i] = vertices[i].normalized;

        }
        if (radius != 1f)
        {
            for(var i =0; i < vertices.Length; i++)
            {
                vertices[i] *= radius;
            }
        }
        Mesh octasphere = new Mesh();
        octasphere.name = "Octasphere";
        octasphere.vertices = vertices;
        octasphere.triangles = triangles;
        octasphere.normals = normals;
        return octasphere;
    }
    private static void CreateOctahedron(Vector3[] vertices,int[]triangles,int resolution)
    {
        int v = 0, vBottom = 0, t = 0;

        for (int i = 0; i < 4; i++)
        {
            vertices[v++] = Vector3.down;
        }

        for (int i = 1; i <= resolution; i++)
        {
            float progress = (float)i / resolution;
            Vector3 from, to;
            vertices[v++] = to = Vector3.Lerp(Vector3.down, Vector3.forward, progress);
            for (int d = 0; d < 4; d++)
            {
                from = to;
                to = Vector3.Lerp(Vector3.down, directions[d], progress);
                t = CreateLowerStrip(i, v, vBottom, t, triangles);
                v = CreateVertexLine(from, to, i, v, vertices);
                vBottom += i > 1 ? (i - 1) : 1;
            }
            vBottom = v - 1 - i * 4;
        }

        for (int i = resolution - 1; i >= 1; i--)
        {
            float progress = (float)i / resolution;
            Vector3 from, to;
            vertices[v++] = to = Vector3.Lerp(Vector3.up, Vector3.forward, progress);
            for (int d = 0; d < 4; d++)
            {
                from = to;
                to = Vector3.Lerp(Vector3.up, directions[d], progress);
                t = CreateUpperStrip(i, v, vBottom, t, triangles);
                v = CreateVertexLine(from, to, i, v, vertices);
                vBottom += i + 1;
            }
            vBottom = v - 1 - i * 4;
        }

        for (int i = 0; i < 4; i++)
        {
            triangles[t++] = vBottom;
            triangles[t++] = v;
            triangles[t++] = ++vBottom;
            vertices[v++] = Vector3.up;
        }

    }
    private static int CreateVertexLine(Vector3 from, Vector3 to, int i, int v, Vector3[] verticies)
    {
        for(int j = 1; j < i; j++)
        {
            verticies[v++] = Vector3.Lerp(from, to, (float)j / i);
        }
        return v;
    }
    private static int CreateLowerStrip(int i, int v, int vBottom, int t, int[] triangles)
    {
        for(int j= 1; j < i; j++)
        {
            triangles[t++] = vBottom;
            triangles[t++] = v - 1;
            triangles[t++] = v;

            triangles[t++] = vBottom++;
            triangles[t++] = v++;
            triangles[t++] = vBottom;
        }
        triangles[t++] = vBottom;
        triangles[t++] = v - 1;
        triangles[t++] = v;
        return t;

    }
    private static int CreateUpperStrip(int i,int v,int vBottom, int t, int[] triangles)
    {
        triangles[t++] = vBottom;
        triangles[t++] = v - 1;
        triangles[t++] = ++vBottom;
        for (int j = 1; j < i; j++)
        {
            triangles[t++] = v -1;
            triangles[t++] = v ;
            triangles[t++] = vBottom;

            triangles[t++] = vBottom;
            triangles[t++] = v++;
            triangles[t++] = ++vBottom;
        }

        return t;
    }
    
}
