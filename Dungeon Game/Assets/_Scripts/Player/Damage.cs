using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tasksystem))]
[RequireComponent(typeof(AIController))]

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
        if(collision.gameObject.tag == "EnemyBody")
        {
            Debug.Log("Damager to Player by object TAG: " + collision.gameObject.tag);
            Debug.Log("Does damage!");
            Health health = gameObject.GetComponent<Health>();
            Tasksystem.hp -= 1;
            if (Tasksystem.hp <= 0)
            {
                Tasksystem.hp = 0;
                gameObject.GetComponentInChildren<Animator>().Play("Die");
                //Debug.Log("Dead!");
            }
             //Apply damage to health
             //HealthController health = gameObject.GetComponent<HealthController>();


        }

        if(collision.gameObject.tag == "Player")
        {
            Health health = gameObject.GetComponent<Health>();
            Debug.Log("Damager to Player by object TAG: " + collision.gameObject.tag);
            Debug.Log("Does damage! " + health.currentHealth);
            health.currentHealth -= 5;
            if (health.currentHealth <= 0)
            {
                AIController.isAlive = false;
                health.currentHealth = 0;
                gameObject.GetComponent<Animator>().SetTrigger("Die");
                //Debug.Log("Dead!");
            }
        }
    }

    
}
