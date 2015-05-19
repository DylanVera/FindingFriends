using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	Transform spawnPoint;
	public static TapController player;
	public GameObject ship;
	public GameObject gameOver;
	public static LevelManager instance = null;
	int score;
	int crashes = 0;
	public int levelCrashMax = 3;
	public static float timer = 0f;     
	public float levelMaxTime = 25f;
	public int levelAbductionCountRequirement = 5;
	public GameObject victory;
	public int world;
	public int level;
	GameObject objective;
	GameObject UIDirection;

	static bool[] Goal;
	Text timerText;
	public GameObject gameGUI;
	float finishTime;
	GameObject gameUI;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			DestroyImmediate(gameObject);

		objective = gameObject.transform.Find("Objective").gameObject;
		objective.gameObject.SetActive(false);
		Goal = new bool[3];
		Time.timeScale = 1f;
		player = ship.GetComponent<TapController>();
		gameUI = Instantiate(gameGUI, gameGUI.transform.position, gameGUI.transform.rotation) as GameObject;
		timerText = gameGUI.gameObject.transform.FindChild("Text").gameObject.GetComponent<Text>();
	}

	// Use this for initialization
	void Start () 
	{
		PlayerPrefs.SetInt("CurrentWorld", world);
		PlayerPrefs.SetInt ("CurrentLevel", level);
		timerText.text = getTimer ().ToString ();
		UIDirection = gameUI.gameObject.transform.FindChild("Direction").gameObject;
		UIDirection.gameObject.SetActive(false);
		//gameOver = GameObject.Find ("Game Over UI");
//			Instantiate (ship, spawnPoint.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player != null)
		{
			if(player.isPlaying())
			{
				timer += Time.deltaTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			int abductees = player.getNumAbducted();
			//player = col.gameObject.GetComponent<TapController>();
			if(abductees >= levelAbductionCountRequirement)
			{
				Debug.Log ("YOU WIN LOSER!");
				Goal[0] = true;
				LevelCleared ();
			}
		}
	}

	public void resetInstance()
	{
		Goal = new bool[3];
		score = 0;
		timer = 0;
		crashes = 0;
	}

	public void GameOver()
	{
		crashes++;
		Time.timeScale = 0f;
		Instantiate (gameOver, gameOver.transform.position, transform.rotation);
	}

	void LevelCleared()
	{
		checkObjectives();

		int stars = 0;

		for(int i = 0; i < Goal.Length; i++)
		{
			if(Goal[i])
				stars++;
		}

		PlayerPrefs.SetInt ("Level" + world + "." + level + "stars", stars);
		Victory();
	}

	void Victory()
	{
		Time.timeScale = 0f;
		crashes = 0;
		finishTime = getTimer();
		timer = 0;
		Instantiate (victory, victory.transform.position, transform.rotation);
	}

	void checkObjectives()
	{
		if(crashes <= levelCrashMax)
			Goal[1] = true;

		if(timer < levelMaxTime)
			Goal[2] = true;
	}

	public void ResetPlayer()
	{
		DestroyImmediate(gameOver.gameObject);
		player.transform.position = gameObject.transform.position;
		player.setPlaying(false);
	}

	public bool[] checkGoals()
	{
		return Goal;
	}

	public bool isPlaying()
	{
		return player.isPlaying();
	}

	public float getTimer()
	{
		return timer;
	}

	public float getFinishTime()
	{
		return finishTime;
	}

	public int getScore()
	{
		return score;
	}

	public void setScore(int points)
	{
		score = points;
		if(score >= levelAbductionCountRequirement)
		{
			objective.gameObject.SetActive(true);
			UIDirection.gameObject.SetActive(true);
		}
			
	}
	/*void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
		}
	}*/
}
