using UnityEngine;
using System.Collections;

public class TractorBeam : MonoBehaviour {

	bool beamActive = false;
	public GameObject ufoBeam;
	PolygonCollider2D beamTrigger;
	public float beamRepelForce = 10f;

	void Start()
	{
		setBeamActive(false);
		beamTrigger = gameObject.GetComponent<PolygonCollider2D>();
		beamTrigger.points = new []{new Vector2(-0.45f,0.3f),new Vector2(0.45f,0.3f), new Vector2(1f, -3), new Vector2(-1f, -3)};
	}

	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Abductable")
		{
			Animator anim = col.gameObject.GetComponent<Animator>();
			anim.SetTrigger ("abducted");
			setBeamActive(true);

			if(col.attachedRigidbody != null)
				col.attachedRigidbody.gravityScale = 0f;
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{	
		if(col.gameObject.tag == "Abductable")  
		{
			col.gameObject.transform.position += (transform.position - col.transform.position).normalized * (Time.deltaTime * 5f);
		}
		/*else if(col.gameObject.layer == 13 && beamActive)
		{
			Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
			rb.AddForce(new Vector2(0, beamRepelForce));
		}*/
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Abductable")
		{
			Animator anim = col.gameObject.GetComponent<Animator>();
			col.attachedRigidbody.gravityScale = 1f;
			anim.SetTrigger("outOfBeam");

		}
		setBeamActive (false);
	}

	public bool isBeamActive()
	{
		return beamActive;
	}

	public void setBeamActive(bool active)
	{
		beamActive = active;
		ufoBeam.SetActive(active);
	}
}