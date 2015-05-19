using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour 
{
	public Canvas pauseGUI;

	public static GameObject instance = null;

	public void Pause()
	{
		if(instance == null)
		{
			instance = Instantiate (pauseGUI.gameObject, pauseGUI.gameObject.transform.position, transform.rotation) as GameObject;
		}
		else
		{
			instance.gameObject.SetActive(true);
		}

		Time.timeScale = 0f;

	}

	public void Resume()
	{
		instance.gameObject.SetActive(false);
		Time.timeScale = 1f;
		//StartCoroutine("Countdown");
	}

	/*IEnumerator Countdown()
	{
		do
		{
			yield return null;
		} while ( animation.isPlaying );
	}*/
}
