using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalOne : MonoBehaviour 
{	
	LevelManager manager;
	Text goalText;

	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		goalText = gameObject.GetComponent<Text>();
		goalText.text = "Found\n" + manager.getScore().ToString () + "/" + manager.levelAbductionCountRequirement.ToString() + " Friends!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
