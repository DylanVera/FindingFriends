using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalThree : MonoBehaviour 
{	
	LevelManager manager;
	Text goalText;
	
	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		goalText = gameObject.GetComponent<Text>();
		goalText.text = "Your Time: " + manager.getFinishTime().ToString ("0.00") + "\nGoal: " + manager.levelMaxTime.ToString ("0.00");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
