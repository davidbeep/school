using UnityEngine;
using System.Collections;

public class EndOfLevel : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c){

		Application.LoadLevel("LevelSelectC1"); // should be the level complete scene

	}
}
