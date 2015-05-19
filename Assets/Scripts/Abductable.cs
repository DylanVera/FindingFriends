using UnityEngine;
using System.Collections;

public class Abductable : MonoBehaviour 
{
	Transform target;
	Rigidbody2D rb;
	FriendController friend;

	// Use this for initialization
	void Start () 
	{		
		rb = gameObject.GetComponent<Rigidbody2D>();
		target = GameObject.Find ("Player").transform;
		friend = gameObject.GetComponent<FriendController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.gravityScale = 0;
		//transform.position = new Vector2(target.transform.position.x, transform.position.y);
		transform.position += (target.position - transform.position).normalized * (Time.deltaTime * 5f);
		//transform.position = Vector3.MoveTowards(transform.position, target.position, 3f * Time.deltaTime);
	}
}