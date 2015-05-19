using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {
	LevelManager manager;
	TapController player;
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();	
		player = transform.root.GetComponent<TapController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "player")
		{
			player.setPlaying(false);
			manager.GameOver();
		}
	}
}
