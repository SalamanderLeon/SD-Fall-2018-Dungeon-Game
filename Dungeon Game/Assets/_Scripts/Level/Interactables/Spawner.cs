using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject prefab;
    public float repeatTime=0f;
    private void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);
    }
    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
