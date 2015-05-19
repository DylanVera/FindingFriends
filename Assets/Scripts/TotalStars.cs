using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TotalStars : MonoBehaviour {

	Text totalStars;

	// Use this for initialization
	void Start () {
		totalStars = gameObject.GetComponent<Text>();
		if(PlayerPrefs.HasKey ("TotalStars"))
			totalStars.text = PlayerPrefs.GetInt ("TotalStars") + "x";
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.HasKey ("TotalStars"))
			totalStars.text = PlayerPrefs.GetInt ("TotalStars") + "x";
	}
}
