using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c){
		if (c.gameObject.name == "Character") {
			Application.LoadLevel ("GameOverMenu"); // should be the level complete scene
			ScoreUI.setWinBool(true) ;
			//ScoreUI.resetScore();
		}
	}
}
