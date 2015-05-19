using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	float speed = 5.0f;
	float rotationSpeed = 500f;
	Transform ship;
	float tilt = 0f;
	Rigidbody2D rb;
	float fuel = 100;
	public Text fuelText;

	// Use this for initialization
	void Start () 
	{
		Physics2D.IgnoreLayerCollision(9,9);                
		transform.position  = new Vector2(0, -2);
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown (0))
		{
			fuel -= 5;
			rb.velocity = Vector2.zero;
			rb.AddForce (Vector2.up * 350);
		}

		if(Input.GetMouseButton(1))
		{
			if(fuel > 0)
			{
				fuel -= 15 * Time.deltaTime;
				rb.AddForce(Vector2.up * 8f);
			}
		}

		//fuelText.text = "Fuel: " + fuel;
			
		/*
		float h = Input.GetAxis ("Horizontal");

		//float v = Input.GetAxis("Vertical");

		tilt +=  -h * rotationSpeed * Time.deltaTime;
		tilt = Mathf.Clamp(tilt, -5,5);
	
		transform.Translate(new Vector2(h,0) * speed * Time.deltaTime);
		ship.transform.rotation = Quaternion.Euler(0,0,tilt);
		 */
		Vector2 stagePos = Camera.main.WorldToScreenPoint(transform.position);

		// if the bird leaves the stage...
		if (stagePos.y > Screen.height || stagePos.y < 43){
			// ... call die function
			die();
		}
	}

	void OnCollisionEnter2D(){
		// call die function
		die();
	}

	public void AddFuel(float gas)
	{
		fuel += gas;

		if(fuel > 100)
			fuel = 100;
	}

	void die()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}