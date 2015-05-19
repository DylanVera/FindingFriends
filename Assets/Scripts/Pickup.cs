using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour 
{
	PlayerController player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("UFO").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.root.tag == "Player")
		{
			Destroy (this.gameObject);
			player.AddFuel(25);
		}
	}
}
