using UnityEngine;
using System.Collections;

public class UINavigation : MonoBehaviour, UI
{

	// Use this for initialization
	void Start ()
	{
	
	}

	public void changeToScene (string key)
	{
		// doing this check so I can use an index for the level select buttons, this simplifies my storage implementation
		int temp;
		bool success;
		success = int.TryParse (key, out temp);

		// success = true means it's one of the game levels
		if (success) {

			GameController.levelIndex = temp - 6; // possible issue here // doesn't seem to be any
			if (GameController.controller.checkIfLevelIsUnlocked (GameController.levelIndex)) {
				Application.LoadLevel (temp);
			} else {
				return;
			}

		} else {
			Application.LoadLevel (key);
		}
	}

	// added overloaded method to take the int index of the level, you can see index by going to file > build settings... in editor
	public void changeToScene (int index)
	{
		Application.LoadLevel (index);
	}

	public void nextLevel ()
	{

		Application.LoadLevel (GameController.levelIndex + 7);
	}
	public void replayLevel ()
	{

		Application.LoadLevel (GameController.levelIndex + 6);
	}
	public void loadChapter2 ()
	{
		// don't need to use this with proper build settings order
		Application.LoadLevel ("LevelSelectC2");
	}



	// Update is called once per frame
	void Update ()
	{
	
	}
}
