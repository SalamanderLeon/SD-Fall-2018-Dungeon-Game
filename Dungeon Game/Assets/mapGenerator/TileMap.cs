using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(MeshFilter)) ]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class TileMap : MonoBehaviour {

    public int Size_X = 100;
    public int Size_Z = 50;
    public float tileSize = 1.0f;

	// Use this for initialization
	void Start ()
    {
        BuildMesh();
	}

    public void BuildMesh()
    {

        int numTiles = Size_X * Size_Z;
        int numTriangles = numTiles * 2;

        int vSize_X = Size_X + 1;
        int vSize_Z = Size_Z + 1;
        int numVerts = vSize_X * vSize_Z;

        // Generate the mesh data
        Vector3[] vertices = new Vector3[numVerts];
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTriangles * 3 ];

        int x, z;
        for (z = 0; z < vSize_Z; z++)
        {
            for ( x = 0; x < vSize_X; x++)
            {
                vertices[z * vSize_X + x] = new Vector3( x*tileSize, 0, z*tileSize );
                normals[z * vSize_X + x] = Vector3.up;
                uv[z * vSize_X + x] = new Vector2((float)x / vSize_X, (float)z / vSize_Z);

                // x = 0, uv.x = 0
                // x = 101, uv.x = 1
                // uv.x = (float)x / vSize_X 
            }
        }

        for (z = 0; z < Size_Z; z++)
        {
            for (x = 0; x < Size_X; x++)
            {
                int squareIndex = z * Size_X + x;
                int triangleOffset = squareIndex * 6;
                triangles[triangleOffset + 0] = z * vSize_X + x +           0;
                triangles[triangleOffset + 1] = z * vSize_X + x + vSize_X + 0;
                triangles[triangleOffset + 2] = z * vSize_X + x + vSize_X + 1;

                triangles[triangleOffset + 3] = z * vSize_X + x +           0;
                triangles[triangleOffset + 4] = z * vSize_X + x + vSize_X + 1;
                triangles[triangleOffset + 5] = z * vSize_X + x +           1;
            }
        }

        // Create a new Mesh and populate with the data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign our mesh to our filter/renderer/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;

    }
	
}
