using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreBehavior : MonoBehaviour
{

	public Text level1_1;
	public Text level1_2;
	public Text level1_3;
	public Text level2_1;
	public Text level2_2;
	public Text level2_3;
	// Use this for initialization
	void Start ()
	{
		level1_1.text = "";
		level1_2.text = "";
		level1_3.text = "";
		level2_1.text = "";
		level2_2.text = "";
		level2_3.text = "";

		if (GameController.controller.getHighScore (0) != 0) {
			level1_1.text = "Level 1-1: " + GameController.controller.getHighScore (0);
		} else {
			level1_1.text = "None";
		}
		if (GameController.controller.getHighScore (1) != 0) {
			level1_2.text = "Level 1-2: " + GameController.controller.getHighScore (1);
		}
		if (GameController.controller.getHighScore (2) != 0) {
			level1_3.text = "Level 1-3: " + GameController.controller.getHighScore (2);
		}
		if (GameController.controller.getHighScore (3) != 0) {
			level2_1.text = "Level 2-1: " + GameController.controller.getHighScore (3);
		}
		if (GameController.controller.getHighScore (4) != 0) {
			level2_2.text = "Level 2-2: " + GameController.controller.getHighScore (4);
		}
		if (GameController.controller.getHighScore (5) != 0) {
			level2_3.text = "Level 2-3: " + GameController.controller.getHighScore (5);
		}


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
