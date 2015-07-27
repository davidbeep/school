using UnityEngine;
using System.Collections;

public class UINavigation : MonoBehaviour, UI {

	// Use this for initialization
	void Start () {
	
	}

	public void changeToScene(string key)
	{
		// doing this check so I can use an index for the level select buttons, this simplifies my storage implementation
		int temp;
		bool success;
		success = int.TryParse(key, out temp);

		// success = true means it's one of the game levels
		if (success) {

			GameController.levelIndex = temp -6; // possible issue here
			if (GameController.controller.checkIfLevelIsUnlocked(GameController.levelIndex)){
			Application.LoadLevel (temp);
			}
			else{
				return;
			}

		} else {
			Application.LoadLevel (key);
		}
	}

	// added overloaded method to take the int index of the level, you can see index by going to file > build settings... in editor
	public void changeToScene(int index)
	{
		Application.LoadLevel(index) ;
	}



	// Update is called once per frame
	void Update () {
	
	}
}
