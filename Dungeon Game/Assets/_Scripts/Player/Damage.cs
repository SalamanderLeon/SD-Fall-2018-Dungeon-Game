using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tasksystem))]
[RequireComponent(typeof(AIController))]

public class Damage : MonoBehaviour {


    public AudioClip[] pain;
    public AudioSource hurt;
    public HealthBar mHealthBarGameObject;
	// Use this for initialization
	void Start () {
        hurt = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Health health = gameObject.GetComponent<Health>();
        if (collision.gameObject.tag == "EnemyBody")
        {
            if (Tasksystem.invincibled == true)
                return;
            if (gameObject.GetComponentInChildren<AIController>().isAlive == false)
                return;

            Debug.Log("Damager to Player by object TAG: " + collision.gameObject.tag);
            Debug.Log("Enemy took damage! " + Tasksystem.hp);
            Tasksystem.hp -= 1;
            Tasksystem.invincibledTime += 3.0f;
            Tasksystem.invincibled = true;
            if (Tasksystem.hp <= 0)
            {
                Tasksystem.hp = 0;
                gameObject.GetComponentInChildren<Animator>().Play("Die");
                gameObject.GetComponent<AIController>().isAlive = false;
                //Debug.Log("Dead!");
            }
             //Apply damage to health
             //HealthController health = gameObject.GetComponent<HealthController>();


        }
        else if(collision.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<AIController>().isAlive == false)
                return;
            Debug.Log("Damager to Player by object TAG: " + collision.gameObject.tag);
            Debug.Log("Does damage! " + health.currentHealth);
            health.TakeDamage(5);

            int randClip = Random.Range(0, pain.Length);
            hurt.clip = pain[randClip];
            hurt.Play();
        }
    }

    
}
