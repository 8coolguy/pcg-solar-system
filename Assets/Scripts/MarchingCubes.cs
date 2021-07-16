using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubes : MonoBehaviour
{
    // Start is called before the first frame update
    public int height;
    public int width;
    public int depth;
    public float scale;
    public float surfaceLevel;
    [SerializeField]
    public GameObject sphere;
    [SerializeField]
    public Material surface;


    [SerializeField]
    
    //we need the those three to set the number of cubes and how it marches throught all the cubes
    //the density function i will use will be the 3d perlin function I created in the previous attempt

    void Start()
    {
        this.gameObject.AddComponent<MeshFilter>();
        this.gameObject.AddComponent<MeshRenderer>();

        
        MarchingSquares(height, width, depth);    
    }
    //creating mesh data
        /// <summary>
        /// need array of verticies which will be all the points on the triangles created by the points that are greater than the surface level 
        /// 
        /// need an array of integers for the intergers
        /// 
        /// </summary>
        
    void MarchingSquares(int height, int width, int depth)
    {
        
        Vector3 pos = transform.position;
        int totalCubes = height * width * depth;
        for(int i =0; i < height; i++)
        {
            for (int j=0; j<width;j++)
            {
                for(int k = 0; k < depth; k++)
                {
                    int cubeIndex = 0 ;
                    float[] cubeIndexs = new float[8];
                    //pos of every sphere or corner of every cube that is marched
                    Vector3 adjustedPos = pos + scale *new Vector3(i,j,k);
                    //GameObject x = Instantiate(sphere, adjustedPos, Quaternion.identity);

                    /*
                    if(Perlin.Noise(((float)i / (float)height) * scale, ((float)j / (float)width) * scale, ((float)k / (float)depth) * scale) > surfaceLevel)
                    {
                        x.GetComponent<MeshRenderer>().material = surface;
                    }

                    */


                    cubeIndexs[4] = Perlin.Noise(((float)i / (float)height) * scale, ((float)j / (float)width) * scale, ((float)k / (float)depth) * scale);
                    cubeIndexs[5] = Perlin.Noise(((float)(i + 1) / (float)height) * scale, ((float)j / (float)width) * scale, ((float)k / (float)depth) * scale);
                    cubeIndexs[6] = Perlin.Noise(((float)(i + 1) / (float)height) * scale, ((float)j / (float)width) * scale, ((float)(k + 1) / (float)depth) * scale);
                    cubeIndexs[7] = Perlin.Noise(((float)i / (float)height) * scale, ((float)j / (float)width) * scale, ((float)(k + 1) / (float)depth) * scale);
                    cubeIndexs[0] = Perlin.Noise(((float)i / (float)height) * scale, ((float)(j + 1) / (float)width) * scale, ((float)k / (float)depth) * scale);
                    cubeIndexs[1] = Perlin.Noise(((float)(i + 1) / (float)height) * scale, ((float)(j + 1) / (float)width) * scale, ((float)k / (float)depth) * scale);
                    cubeIndexs[2] = Perlin.Noise(((float)(i + 1) / (float)height) * scale, ((float)(j + 1) / (float)width) * scale, ((float)(k + 1) / (float)depth) * scale);
                    cubeIndexs[3] = Perlin.Noise(((float)i / (float)height) * scale, ((float)(j + 1) / (float)width) * scale, ((float)(k + 1) / (float)depth) * scale);
                    
                    
                    for(int corner=0;corner<cubeIndexs.Length;corner++)
                    {
                        if (cubeIndexs[corner] > surfaceLevel)
                        {
                            switch (corner)
                            {
                                case 0:
                                    cubeIndex += 8;
                                    break;
                                case 1:
                                    cubeIndex += 4;
                                    break;
                                case 2:
                                    cubeIndex += 2;
                                    break;
                                case 3:
                                    cubeIndex += 1;
                                    break;
                                case 4:
                                    cubeIndex += 128;
                                    break;
                                case 5:
                                    cubeIndex += 64;
                                    break;
                                case 6:
                                    cubeIndex += 32;
                                    break;
                                case 7:
                                    cubeIndex += 16;
                                    break;
                                default:
                                    Debug.Log("Candice...Can dis dick fit in your mouth ?");
                                    break;
                            }
                        }
                    }
                    //Debug.Log(cubeIndex);
                    int[] triangleIdex = Table.TriangleConnections(cubeIndex);
                    int bEdges = Table.EdgeConnections(cubeIndex);
                    
                    
                    CreateTriangles(bEdges,triangleIdex,adjustedPos);
                    

                }
            }
        }
    }

    void CreateTriangles(int bEdges,int[] triangleArray,Vector3 pos)
    {
        //Vector3 pos;
        
        Mesh mesh = this.gameObject.GetComponent<MeshFilter>().mesh;
        
        //the mesh info
        List<Vector3> verts = new List<Vector3>(mesh.vertices);
        List<int> triangles = new List<int>(mesh.triangles);
        //the info to make each triangle
        int[] trianglePoints = new int[12];
        


        byte[] bits =System.BitConverter.GetBytes(bEdges);

        BitArray edgePos = new BitArray(bits);
        
        for(int bit =0;bit<edgePos.Length;bit++)
        {
            
            if (edgePos[bit] == true)
            {
                Vector3 temp = CubeEdges(bit, pos);
                trianglePoints[bit] = verts.Count;
                verts.Add(temp);
                
            }
        }
         
        //use to make the vertices Table.EdgeConnections(cube);
        foreach (int t in triangleArray)
        {
            if(t!=-1)
            {
                triangles.Add(trianglePoints[t]);
            }
        }//updating verts and triangles
        mesh.vertices= verts.ToArray();
        mesh.triangles = triangles.ToArray();

        //updating the mesh
        this.gameObject.GetComponent<MeshFilter>().mesh = mesh;
        




    }

    Vector3 CubeEdges(int edgeNum,Vector3 pos)
    {
        Vector3 edgePos = new Vector3();
        //the resources give where the edges are of each 
        switch (edgeNum)
        {
            case 0://0
                edgePos = pos + new Vector3(.5f,1,0)*scale;
                break;
            case 1://1
                edgePos = pos + new Vector3(1, 1, .5f) * scale;
                break;
            case 2://2
                edgePos = pos + new Vector3(.5f, 1, 1) * scale;
                break;
            case 3://3
                edgePos = pos + new Vector3(0, 1, .5f) * scale;
                break;
            case 4://0
                edgePos = pos + new Vector3(.5f, 0, 0) * scale;
                break;
            case 5://1
                edgePos = pos + new Vector3(1, 0, .5f) * scale;
                break;
            case 6://2
                edgePos = pos + new Vector3(.5f, 0, 1) * scale;
                break;
            case 7://3
                edgePos = pos + new Vector3(0, 0, .5f) * scale;
                break;
            case 8://0
                edgePos = pos + new Vector3(0, .5f, 0) * scale;
                break;
            case 9://1
                edgePos = pos + new Vector3(1f, .5f, 0) * scale;
                break;
            case 10://2
                edgePos = pos + new Vector3(1, .5f, 1) * scale;
                break;
            case 11://3
                edgePos = pos + new Vector3(0, .5f, 1) * scale;
                break;
            default:
                Debug.Log("NoEdge");
                break;
            
        }
        


        return edgePos;
    }







}
