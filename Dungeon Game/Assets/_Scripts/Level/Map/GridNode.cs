using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode : MonoBehaviour {

    public float size = 10;
    public GameObject tilePrefab;
    public GameObject[] mPF;

	// Use this for initialization
	void Start () {
        //Load();
        Generate();
    }
	
    void Load()
    {
        if (tilePrefab)
        {
            GameObject.Instantiate(tilePrefab, transform.position, Quaternion.identity);
        }
    }

    void Generate()
    {
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                float x = i * 10;
                float y = j * 10;
                int n = Random.Range(0, mPF.Length);
                GameObject room = Instantiate(mPF[n], new Vector3(x, 0, y), Quaternion.identity) as GameObject;
                room.transform.parent = GameObject.Find("level").transform;
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}


    void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(size, 1, size));
    }


}



// Download some nice room assets
// Create trigger volume (door), load the next room
// Get map generation working based on trigger volumes