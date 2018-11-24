using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHinge : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.eulerAngles = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {


    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            iTweenEvent.GetEvent(gameObject, "DoorOpen").Play();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            iTweenEvent.GetEvent(gameObject, "DoorClose").Play();
        }
    }



    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{

    //}

    // void OnCollisionEnter(Collision collision)
    //{

    //}

    // void OnCollisionExit(Collision collision)
    //{
    //    
    //}

}
