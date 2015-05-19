using UnityEngine;
using System.Collections;

public class JetEnemy : MonoBehaviour 
{
	public LayerMask shootable;
	public GameObject missile;
	float shootDelay = 2f;
	float shootTimer = 2f;
	public int direction = -1;
	public float speed = 5f;
	float range = 7.5f;
	public float pathTimer = 5f;
	Misssle missleControl;
	GameObject gun;
	bool facingRight = true;
	float power;


	// Use this for initialization
	void Start () 
	{
		power = speed * 1.5f;
		if(direction == -1)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			facingRight = false;
		}

		gun = gameObject.transform.FindChild("Gun").gameObject;
		missleControl = missile.GetComponent<Misssle>();
		Physics2D.IgnoreLayerCollision(10,10);
		InvokeRepeating("flip", pathTimer, pathTimer);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
		//transform.Translate (-Vector2.right * 10f * Time.deltaTime);
		RaycastHit2D hit = Physics2D.Raycast (transform.position,  direction * transform.right, range, shootable);

		Debug.DrawRay (transform.position, direction * transform.right * range, Color.red);

		shootTimer += Time.deltaTime;

		if(hit)
		{
			if(hit.collider.gameObject.tag == "Player")
			{
				if(shootTimer >= shootDelay)
				{
					shoot();
				}
			}
		}
	}

	void shoot()
	{
		shootTimer = 0;

		Rigidbody2D projectile = (Instantiate (missile, gun.transform.position, transform.rotation) as GameObject).GetComponent<Rigidbody2D>();
		if(!facingRight)
		{
			Vector3 theScale = projectile.transform.localScale;
			theScale.x *= -1;
			projectile.transform.localScale = theScale;
		}

		projectile.velocity = (direction > 0 ? Vector2.right * power : -Vector2.right * power);
	}

	void flip()
	{
		Vector3 theScale = transform.localScale;
		facingRight = !facingRight;
		theScale.x *= -1;
		direction *= -1;
		transform.localScale = theScale;

	}
}
