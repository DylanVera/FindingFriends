using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour 
{

	int page = 1;
	GameObject page1;
		public GameObject page2;
	// Use this for initialization
	void Start () 
	{
		page1 = GameObject.Find("Page 1").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nextPage()
	{
		Debug.Log ("HELP");
		if(page == 1)
		{ 	
			page1.gameObject.SetActive(false);
			page2.gameObject.SetActive(true);
			page = 2;
		}
		else 
		{
			Application.LoadLevel("main menu");
		}
	}
}
