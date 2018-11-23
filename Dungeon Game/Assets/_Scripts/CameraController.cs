using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Target;
    GameObject Player;
    Vector3 offset;

	// Use this for initialization
	void Start () {
		transform.position = Target.transform.position + new Vector3(5.0f, 8.0f, 5.0f);
		transform.eulerAngles = new Vector3(45, 225, 0);

        Player = GameObject.FindWithTag("Player");
        offset = Player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        transform.position = Player.transform.position - offset;
    }
}
