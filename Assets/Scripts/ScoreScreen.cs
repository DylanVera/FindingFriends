using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScreen : MonoBehaviour {
	LevelManager levelmanager;
	bool[] goal;
	public Image star1, star2, star3;

	// Use this for initialization
	void Start () {
		levelmanager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		goal = levelmanager.checkGoals();
		Debug.Log (goal[0]);
		if(goal[0])
			star1.gameObject.SetActive(true);
		if(goal[1])
			star2.gameObject.SetActive(true);
		if(goal[2])
			star3.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
