using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public float size = 10;
	public GameObject tilePrefab;
	public GameObject[] mPF;
	public int stairRate = 0;
	bool stairs = false;

	// Use this for initialization
	void Start()
	{
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

				if (Random.Range(1, 10) < stairRate && stairs == false)
				{
					GameObject room = Instantiate(mPF[mPF.Length - 1], new Vector3(x, 0, y), Quaternion.identity) as GameObject;
					room.transform.parent = GameObject.Find("level").transform;
					stairs = true;
				}
				else
				{
					int n = Random.Range(0, mPF.Length - 1);
					GameObject room = Instantiate(mPF[n], new Vector3(x, 0, y), Quaternion.identity) as GameObject;
					room.transform.parent = GameObject.Find("level").transform;
					++stairRate;
				}
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
		Gizmos.DrawCube(transform.position, new Vector3(10, 1, 10));
	}
}
