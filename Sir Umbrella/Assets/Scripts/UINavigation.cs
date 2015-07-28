using UnityEngine;
using UnityEngine.UI ;
using System.Collections;

public class UINavigation : MonoBehaviour, UI
{

	public Button level1;
	public Button level2;
	public Button level3;
	public Sprite active1;
	public Sprite inactive1;
	public Sprite active2;
	public Sprite inactive2;
	public Sprite active3;
	public Sprite inactive3;

	// Use this for initialization
	void Start ()
	{
		if (GameController.controller.checkIfLevelIsUnlocked (1)) {
			level2.image.sprite = active2;
		} else {
			level2.image.sprite = inactive2;
		}

		if (GameController.controller.checkIfLevelIsUnlocked (2)) {
			level3.image.sprite = active3;
		} else {
			level3.image.sprite = inactive3;
		}
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
