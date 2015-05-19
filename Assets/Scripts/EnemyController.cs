using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	float speed = 5.0f;
	// Use this for initialization
	void Start () 
	{
		Physics2D.IgnoreLayerCollision(11,11);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (-Vector2.right * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.root.tag == "Player")
		{
			Destroy (col.gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
			
			
			Destroy (this.gameObject);
	}
}