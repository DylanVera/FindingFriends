using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float collisionDelay = 0.25f;
	Collider2D projectileCol;
	public GameObject Explosion;
	public float lifetime = 3f;
	float timer = 0f;

	// Use this for initialization
	void Start () {
	
		projectileCol = gameObject.GetComponent<Collider2D>();
		projectileCol.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer > lifetime)
			Destroy (gameObject);
		if(collisionDelay >= 0)
		{
			collisionDelay -= Time.deltaTime;
		}
		if(collisionDelay <= 0 && !projectileCol.enabled)
		{
			projectileCol.enabled = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);

		if(col.gameObject.layer != 11 && col.gameObject.layer != 12)
			Destroy (col.gameObject);

		Instantiate (Explosion, col.transform.position, Explosion.transform.rotation);
	}
}
