using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour 
{
	float timer = 60f;
	Text timerText;

	// Use this for initialization
	void Start () 
	{
		timerText = gameObject.GetComponent<Text>();
		timerText.text = timer.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		timerText.text = Mathf.Floor (timer).ToString ();

		if(timer <= 0)
			Application.LoadLevel (Application.loadedLevel);
	}
}