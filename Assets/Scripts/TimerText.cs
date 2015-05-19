using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerText : MonoBehaviour {

	LevelManager manager;
	Text timerText;

	void Awake()
	{
		manager = GameObject.Find ("Start_Finish").GetComponent<LevelManager>();
		timerText = gameObject.GetComponent<Text>();
	}

	// Use this for initialization
	void Start () {
		timerText.text = Mathf.Floor(manager.getTimer()).ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		if(manager.isPlaying ())
		{
			timerText.text = Mathf.Floor(manager.getTimer()).ToString ();
		}
	}
}
