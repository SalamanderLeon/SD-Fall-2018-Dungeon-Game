using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftDoorHinge : MonoBehaviour {

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {


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
}
