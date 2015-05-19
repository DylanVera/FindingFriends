using UnityEngine;
using System.Collections;

public class MissileTurret : MonoBehaviour 
{
	public LayerMask shootable;
	public GameObject missile;
	float shootDelay = 2f;
	float shootTimer = 2f;
	public int direction = -1;
	public float speed = 1f;
	float range = 7.5f;
	public float pathTimer = 4f;
	GameObject gunBarrel;
	public float power = 5f;
	
	Rigidbody2D target;
	
	// Use this for initialization
	void Start () 
	{
		gunBarrel = gameObject.transform.FindChild("GunBarrel").gameObject;
		/*if(direction == -1)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}*/
		
		Physics2D.IgnoreLayerCollision(10,10);
		//InvokeRepeating("flip", pathTimer, pathTimer);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
		//transform.Translate (-Vector2.right * 10f * Time.deltaTime);
		RaycastHit2D hit = Physics2D.CircleCast(new Vector2(transform.position.x, transform.position.y + 0.5f), 3.5f, Vector2.zero);
		
		shootTimer += Time.deltaTime;
		
		if(hit)
		{
			if(hit.collider.gameObject.tag == "Player")
			{
				target = hit.collider.attachedRigidbody;
				Vector3 diff = (Vector3)target.position - transform.position;
				diff.Normalize();
				
				float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

				if(shootTimer >= shootDelay)
				{
					shoot ();
				}
			}
		}
	}

	void shoot()
	{
		shootTimer = 0;
		
		/*float distance = Vector2.Distance(target.transform.position, gunBarrel.transform.position);
		float angleToPoint = Mathf.Atan2(target.transform.position.y - gunBarrel.transform.position.y, target.transform.position.x - gunBarrel.transform.position.x);
		float distanceFactor = 1/1000;
		float angleCorrection = (Mathf.PI*0.18f) * (distance * distanceFactor);
		*/
		
		Rigidbody2D projectile = (Instantiate (missile, gunBarrel.transform.position, gunBarrel.transform.rotation) as GameObject).GetComponent<Rigidbody2D>();
		//Debug.DrawRay(gunBarrel.transform.position, target.transform.position - transform.position ,Color.red, 3f);
		//projectile.velocity = target.transform.position - transform.position;
		//projectile.velocity = new Vector2(Mathf.Cos (angleToPoint-angleCorrection) * power, Mathf.Sin(angleToPoint-angleCorrection) * power);
		//projectile.velocity = (direction > 0 ? Vector2.right * 15f : -Vector2.right * 15f);
	}
	
	void flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		direction *= -1;
		transform.localScale = theScale;
		
	}
}
