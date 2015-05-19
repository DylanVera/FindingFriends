using UnityEngine;
using System.Collections;

public class FuelSpawner : MonoBehaviour 
{
	public GameObject pickup;
	public float spawnTime;
	public Transform[] spawnPoints;
	GameObject scrollingScene;
	
	void Start ()
	{
		spawnTime = Random.Range (2.0f, 5.0f);
		scrollingScene = GameObject.Find ("Scene Objects");
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		spawnTime = Random.Range (2.0f, 5.0f);
		float spawnY = Random.Range (-1.5f,1.5f);

		GameObject spawnedPickup;
		//Instantiate (enemy, transform.position, Quaternion.identity);
		spawnedPickup = Instantiate (pickup, new Vector2(transform.position.x, spawnY), transform.rotation) as GameObject;
		spawnedPickup.transform.parent = scrollingScene.transform;
	}	
}
