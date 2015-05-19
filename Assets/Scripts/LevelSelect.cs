using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	
	private int worldIndex;   
	private int levelIndex;   
	private int stars = 0;
	
	void  Start (){
		//loop thorugh all the worlds
		checkStars ();
		CheckLockedLevels();
		/*for(int i = 1; i <= LockLevel.worlds; i++){
			if(Application.loadedLevelName == "World"+i){
				worldIndex = i;
				CheckLockedLevels(); 
			}
		}*/
	}

	void Update()
	{
	}
	
	//Level to load on button click. Will be used for Level button click event 
	public void Selectlevel(string worldLevel)
	{
		Application.LoadLevel("Level" + worldLevel); //load the level
	}
	
	//uncomment the below code if you have a main menu scene to navigate to it on clicking escape when in World1 scene
	/*public void  Update (){
  if (Input.GetKeyDown(KeyCode.Escape) ){
   Application.LoadLevel("MainMenu");
  }   
 }*/

	void checkStars()
	{
		stars = 0;

		for(int i = 1; i < LockLevel.levels; i++)
		{
			stars += PlayerPrefs.GetInt ("Level1" +"." + i + "stars");
			Debug.Log ("Total Stars Earned: " + stars);
		}

		PlayerPrefs.SetInt ("TotalStars", stars);
	}

	//function to check for the levels locked
	public void  CheckLockedLevels (){
		//loop through the levels of a particular world
		for(int j = 1; j < LockLevel.levels; j++)
		{
			levelIndex = (j+1);

			Debug.Log (stars >= ((levelIndex - 1) * 2));
			if(PlayerPrefs.GetInt ("TotalStars") >= ((levelIndex - 1) * 2))
				PlayerPrefs.SetInt ("level"+worldIndex.ToString() +":" + (levelIndex).ToString(), 1);

			if((PlayerPrefs.GetInt("level"+worldIndex.ToString() +":" + (levelIndex).ToString()))==1)
			{
				GameObject.Find("LockedLevel"+(j+1)).active = false;
			}
		}
	}
}