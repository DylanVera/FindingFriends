using UnityEngine;
using System.Collections;

public class CowSpawner : MonoBehaviour 
{

	float spawnTime = 3f;
	public GameObject enemy;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn ()
	{
		//set screen Bounds
		Vector3 screenBounds = new Vector3(Screen.width, 0, Screen.height);
		float screenX = (screenBounds.x*5)/100;
		
		spawnTime = Random.Range(0.1f,1.0f);
		
		float spawnX = Random.Range (-6.5f, 6.5f);
		
		GameObject cow = Instantiate (enemy, new Vector2(spawnX, -4.611772f), Quaternion.identity) as GameObject;
		cow.transform.parent = transform.parent.transform.parent;
	}

}