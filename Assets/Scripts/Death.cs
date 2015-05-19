using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	void Start()
	{
		Physics2D.IgnoreLayerCollision(0,10);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy (col.gameObject);
			Application.LoadLevel (Application.loadedLevel);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "Player")
		{
			Destroy (col.transform.root.gameObject);
			Application.LoadLevel (Application.loadedLevel);
		}
		else
			Destroy (col.transform.gameObject);
	}
}