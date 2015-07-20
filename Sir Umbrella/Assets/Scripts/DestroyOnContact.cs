using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c){

		if (c.gameObject.name == "Character") {
			Destroy (c.gameObject);
			Application.LoadLevel("LevelSelectC1"); // should be game over screen when we get art for it
			ScoreUI.resetScore();
			}
		}
	}

