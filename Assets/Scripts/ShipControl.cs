using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class ShipControl : MonoBehaviour {

	GameObject cube;
	public Transform center;
	public Vector3 desiredPosition;
	public float radius = 5.0f;
	public float radiusSpeed = 50f;
	public float rotationSpeed = 80.0f;
	
	void Start () 
	{
		cube = GameObject.FindWithTag("Planet");
		center = cube.transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 5.0f;
	}
	
	void Update () 
	{
		float h  = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		transform.RotateAround (center.position, Vector3.forward, -h * rotationSpeed * Time.deltaTime);
		//desiredPosition = (transform.position - center.position).normalized * radius * v + center.position;
		//if(v != 0)
		//	transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);
	}

}