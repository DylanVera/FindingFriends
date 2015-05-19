using UnityEngine;
using System.Collections;

public class Misssle : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy (gameObject);

		if(col.gameObject.layer != 11 && col.gameObject.layer != 12)
			Destroy (col.gameObject);
	}
	
}
