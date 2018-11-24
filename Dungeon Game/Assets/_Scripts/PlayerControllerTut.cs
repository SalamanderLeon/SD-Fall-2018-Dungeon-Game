using UnityEngine;

public class PlayerControllerTut : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public Animator anim;

	void Start()
	{
		//anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		

		if (Input.GetKeyDown(KeyCode.F))
		{
			Fire();
		}
	}

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("forward", true);
		}
		else
		{
			anim.SetBool("forward", false);
		}
	}

	void Fire()
	{
		//spawn bullet
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		
		//add velocity
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		//destroy in 2 seconds
		Destroy(bullet, 2.0f);
	}
}