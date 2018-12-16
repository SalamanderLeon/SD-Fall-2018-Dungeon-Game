using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIController : MonoBehaviour {

    public int awarenessRadius = 2;

    public bool isAwared = false;
    public static bool isAlive = true;
    public float personalSpaceRadius = 1.5f;
    public float speed = 0.01f;
    GameObject player;

    public Animator anim;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

	// Update is called once per frame
	void Update () {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("walking", false);
        anim.SetBool("attacking", false);


        if (player != null)
        {
            // Awareness
            isAwared = Vector3.Magnitude(transform.position - player.transform.position) < awarenessRadius;
            if (isAwared && isAlive)
            {
                Vector3 lookAt = (player.transform.position - transform.position);
                lookAt.y = 0.0f;

                // If player is in range will move towards them
                if (Vector3.Magnitude(player.transform.position - transform.position) > personalSpaceRadius)
                {
                    // Apply force
                    anim.SetBool("walking", true);
                    transform.position = transform.position + lookAt * speed;
                }
                // If in range will attack
                if (Vector3.Magnitude(player.transform.position - transform.position) < personalSpaceRadius)
                {
                    anim.SetBool("attacking", true);
                }

                lookAt = transform.forward + lookAt * 0.1f;
                transform.forward = Vector3.Normalize(lookAt);
            }
            if (isAlive == false)
            {
                Destroy(gameObject, 3.0f);
            }
        }


	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, awarenessRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, personalSpaceRadius);


        if (isAwared) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, player.transform.position);

        }
    }
}
