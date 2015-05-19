using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject enemy;
	public float spawnTime;
	public Transform[] spawnPoints;
	GameObject scrollingScene;

	void Start ()
	{
		spawnTime = Random.Range (0.2f, 3.0f);
		scrollingScene = GameObject.Find ("Scene Objects");
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		spawnTime = Random.Range (0.2f, 3.0f);
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		GameObject spawnedEnemy;
		//Instantiate (enemy, transform.position, Quaternion.identity);
		spawnedEnemy = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
		spawnedEnemy.transform.parent = scrollingScene.transform;
	}	
}
