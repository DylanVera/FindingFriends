using UnityEngine;
using System.Collections;

public class Startgame : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Play()
	{
		Application.LoadLevel("LevelSelect");
	}

	public void HowToPlay()
	{
		Application.LoadLevel("HowToPlay");
	}
}
