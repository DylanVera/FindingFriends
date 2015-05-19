using UnityEngine;
using System.Collections;

public class PlanetaryGravity : MonoBehaviour 
{
	Rigidbody2D rb;
	GameObject planet;
	Vector2 dir;
	float gravity = 9.81f;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		planet = GameObject.Find ("Planet");
	}

	void Update()
	{
		dir = planet.transform.position - transform.position;
		transform.rotation = Quaternion.Slerp (transform.rotation,Quaternion.FromToRotation(transform.up, dir) * transform.rotation, 50 * Time.deltaTime);
		rb.AddForce(dir * gravity);
	}

	public void GravSwitch(bool active)
	{
		if(active)
			gravity = 9.81f;
		else
			gravity = 0;
	}
	

	/*
	GameObject planet;
	Rigidbody2D thisShip;
	float speed = 5f;
	float rotationSpeed = 100f;

	// Use this for initialization
	void Start () {
		planet = GameObject.Find ("Planet");
		thisShip = gameObject.GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector2 dir = planet.transform.position - transform.position;

		transform.RotateAround(planet.transform.position, Vector3.forward, -h * rotationSpeed * Time.deltaTime);
		Debug.Log(Vector2.Distance(transform.position, planet.transform.position));
		transform.Translate(dir * v * speed * Time.deltaTime);
	}*/
}