using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public HealthBar mHealthBarGameObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Damager to Player by object TAG: " + collision.gameObject.tag);
        if(collision.gameObject.tag == "enemy")
        {
            // Apply damage to health
            // HealthController health = gameObject.GetComponent<HealthController>();

            if (mHealthBarGameObject)
            {
                mHealthBarGameObject.ApplyDamage(10);
            }
            
        }
    }
}
