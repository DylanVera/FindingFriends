using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalTwo : MonoBehaviour 
{	
	LevelManager manager;
	Text goalText;
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		goalText = gameObject.GetComponent<Text>();
		goalText.text = "Max Crashes: " + manager.levelCrashMax;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
