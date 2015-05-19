using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	LevelManager manager;
	Text scoreText;
	
	void Awake()
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		scoreText = gameObject.GetComponent<Text>();
	}
	
	// Use this for initialization
	void Start () {
		scoreText.text = "0/" + manager.levelAbductionCountRequirement;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(manager.isPlaying ())
		{
			scoreText.text = manager.getScore() + "/" + manager.levelAbductionCountRequirement;
		}
	}
}
