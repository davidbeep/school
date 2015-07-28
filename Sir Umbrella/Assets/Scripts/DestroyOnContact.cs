using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour
{

	void OnTriggerEnter2D (Collider2D c)
	{

		if (c.gameObject.name == "Character") {
			Destroy (c.gameObject);
			GameController.levelIndex = Application.loadedLevel - 6; // get index now so it doesn't get overwritten when switching to gameover scene //-6 because level 1-1 starts at number 6 on the build settings, level1-2 is 7 and so on...
			Application.LoadLevel ("GameOverMenu");
			ScoreUI.setWinBool (false);
			//ScoreUI.resetScore();
		}
	}
}

