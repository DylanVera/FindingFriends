using UnityEngine;
using System.Collections;

public class RetryLevel : MonoBehaviour 
{
	LevelManager manager;
	int world, level;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.HasKey ("CurrentWorld"))
			world = PlayerPrefs.GetInt ("CurrentWorld");

		if(PlayerPrefs.HasKey ("CurrentLevel"))
			level = PlayerPrefs.GetInt ("CurrentLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Retry()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Reset()
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		manager.resetInstance();
		Retry ();
	}

	public void QuitToMainMenu()
	{
		Application.LoadLevel ("main menu");
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		manager.resetInstance();
	}

	public void QuitToLevelSelect()
	{
		Application.LoadLevel ("LevelSelect");
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		manager.resetInstance();
	}
}
