using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour {

	Rigidbody2D rb;
	GameObject player; //your missile's target
	public float speed = 5;
	float lifeSpan = 7f;
	float _velocity = 10f;
	float _torque = 5f;	
	Transform _target;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.Find ("UFO(Clone)");

		float distance = Mathf.Infinity;
			
			var diff = (player.transform.position - transform.position).sqrMagnitude;   
			if(diff < distance)
			{
				distance = diff;				
				_target =  player.transform;
				
			}			
		}

	


	
	void Update () {
		Vector2 dist = new Vector2();
		if(player != null)
		{
			dist = player.transform.position - transform.position; //difference in space between target and player
			dist = dist.normalized; //makes sure it's based on direction. Without it, the missile slows down the closer the missile is to target.
		}

		lifeSpan -= Time.deltaTime;
		if(lifeSpan <= 0)
			Destroy (gameObject);
		rb.AddForce (dist * speed);
		//transform.Translate (transform.forward * 3 * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);

		if(col.gameObject.layer != 12 && col.gameObject.layer != 11)
			Destroy (col.gameObject);

	}
}
