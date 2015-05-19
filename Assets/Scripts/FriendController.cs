using UnityEngine;
using System.Collections;

public class FriendController : MonoBehaviour 
{
	float timer;
	public float speed = 1.0f;
	public int direction = 1;
	public float pathTimer = 5f;
	bool facingRight = true;
	public bool randompath = false;
	public bool randomDirection = false;

	// Use this for initialization
	void Start () 
	{
		if(randompath)
		{
			pathTimer = Random.Range (1f, 5f);
		}

		if(randomDirection)
		{
			direction = Random.Range (-1,2);
			
			if(direction > 0)
				direction = 1;
			else
				direction = -1;
		}

		if(direction == -1)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			facingRight = false;
		}
			

		Physics2D.IgnoreLayerCollision(8, 8);
		InvokeRepeating("switchDirection", pathTimer, pathTimer);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

		/*var pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, -7.7f, 7.7f);
		transform.position = pos;*/

		/*if(transform.position.x == -7.7)
			switchDirection(1);
		if(transform.position.x == 7.7)
			switchDirection(-1);

		timer -= Time.deltaTime;

		if(timer <= 0)
		{
			switchDirection(2);
		}*/

		//	Debug.Log("Direction:" + direction + "\nTimer: " + timer);
	}

	void switchDirection()
	{
		direction *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facingRight = !facingRight;
	}
}