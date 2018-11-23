using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Vector3 lastPosition;

	// Use this for initialization
	void Start ()
    {
        lastPosition = transform.position;


    }
	
	// Update is called once per frame
	void Update ()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Swing");
        }
        

        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Die");
        }

/*        if( Vector3.Magnitude(transform.position - lastPosition) > 0)
        {
            Vector3 forward = (transform.position - lastPosition).normalized;
            forward.y = 0;
            transform.forward = forward;
        }
 */

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1);

        Gizmos.color = Color.yellow;
        if (Vector3.Magnitude(transform.position - lastPosition) > 0)
        {
            Vector3 forward = (transform.position - lastPosition).normalized;
            forward.y = 0;
            
            Gizmos.DrawLine(lastPosition, lastPosition + forward * 2);
        }

        lastPosition = transform.position;


    }
}