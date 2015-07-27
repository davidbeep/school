using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "Character") {

			GameController.levelIndex = Application.loadedLevel - 6; // get index now so it doesn't get overwritten when switching to gameover scene //-6 because level 1-1 starts at number 6 on the build settings, level1-2 is 7 and so on...
			Application.LoadLevel ("GameOverMenu"); 
			ScoreUI.setWinBool(true) ;

			// check if score is greater than high score for this level and update highscore if true
			if (GameController.controller.getHighScore(GameController.controller.getCurrentLevelIndex()) < ScoreUI.count ){
				GameController.controller.setHighScore(GameController.controller.getCurrentLevelIndex(),ScoreUI.count);
					GameController.controller.saveToFile();
			}
			//ScoreUI.resetScore();
		}
	}
}
