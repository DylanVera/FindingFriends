using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Abduct : MonoBehaviour 
{
	TractorBeam beam;
	public Text scoreText;
	TapController player;
	int score = 0;
	public GameObject pointsUI;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<TapController>();
		beam = transform.parent.transform.FindChild("Tractor Beam").GetComponent<TractorBeam>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		//if(beam.isBeamActive())
		//{
			if(col.gameObject.tag == "Abductable")
			{
				player.Abduct(col.gameObject);
				beam.setBeamActive(false);
				Instantiate(pointsUI, transform.position, transform.rotation);
			}


		//}
	}
}