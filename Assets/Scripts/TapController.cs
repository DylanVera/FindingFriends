using UnityEngine;
using System.Collections;

public class TapController : MonoBehaviour 
{
	LevelManager manager;
	Rigidbody2D rb;
	float xInputMargin = 25f;
	float midPoint = Screen.width/3;
	Queue abductees;
	static int score = 0;
	float xVelocity = 10f;
	float yVelocity = 15.0f;
	float yVelDelayTime = 1f;
	float h;
	private static float direction = 0f;
	static bool playing = false;
	TractorBeam beam;
	Pauser pause;
	bool paused = false;

	void Awake()
	{
		pause = gameObject.GetComponent<Pauser>();
		beam = gameObject.transform.FindChild("Tractor Beam").GetComponent<TractorBeam>();
		manager = GameObject.Find("Start_Finish").GetComponent<LevelManager>();
		abductees = new Queue();
		score = 0;
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.gravityScale = 0f;
		rb.isKinematic = true;
		playing = false;
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			if(!paused)
				pause.Pause ();

			else
				pause.Resume();
		}
			


		//Debug.Log (rb.velocity);
		Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		h = Input.GetAxisRaw ("Horizontal");
		if(Input.GetMouseButton(0) ||  h != 0)
		{
			playing = true;
			rb.isKinematic = false;
			rb.gravityScale = 0;
			if(Input.mousePosition.x < midPoint || Input.GetKey (KeyCode.A))
			{
				//rb.AddForce(new Vector2(-xVelocity,yVelocity), ForceMode2D.Impulse);
				rb.AddForce(new Vector2(-xVelocity,yVelocity));
			}if((Input.mousePosition.x < midPoint * 2 && Input.mousePosition.x > midPoint))
			{
				//rb.AddForce(new Vector2(0,yVelocity), ForceMode2D.Impulse);
				rb.AddForce (new Vector2(0, yVelocity));
			}
			else if(Input.mousePosition.x > midPoint * 2 || Input.GetKey (KeyCode.D))
			{
				//rb.AddForce(new Vector2(xVelocity,yVelocity), ForceMode2D.Impulse);
				rb.AddForce(new Vector2(xVelocity, yVelocity));
			}

			rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10.0f);
		}
		if(Input.GetMouseButtonUp(0) || Input.GetButtonUp ("Jump") || Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp(KeyCode.D))
		{
				h = 0;
				rb.gravityScale = 0.7f;
		}
		direction = Mathf.Sign (rb.velocity.x);
	}

	public void Abduct(GameObject abductee)
	{
		abductees.Enqueue(abductee);
		abductee.SetActive(false);
		beam.setBeamActive(false);
		score = abductees.Count;
		manager.setScore(score);
		Debug.Log ("Score: " + score);
	}

	public int getNumAbducted()
	{
		Debug.Log ("Returning: " + score);
		return score;
	}

	public bool isPlaying()
	{
		return playing;
	}


	public void setPlaying(bool play)
	{
		playing = play;
	}

	public float getDirection()
	{
		return direction;
	}

}
