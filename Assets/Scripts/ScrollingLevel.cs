using UnityEngine;
using System.Collections;

public class ScrollingLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector2.right * Time.deltaTime * 2.5f);
	}
}
