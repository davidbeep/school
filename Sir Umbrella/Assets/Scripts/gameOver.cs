using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class gameOver : MonoBehaviour
{

	private int score ;
	private Text title ;
	private Text scoreText ;
	private Text highScoreText ;
	private GameObject nextLevelButton;
	private GameObject nextChapterButton;
	private GameObject shareButton;

	
	// Use this for initialization
	void Start ()
	{

		score = ScoreUI.getScore ();
		scoreText = GameObject.FindGameObjectWithTag ("scoreText").GetComponent<Text> (); 
		highScoreText = GameObject.FindGameObjectWithTag ("highScoreText").GetComponent<Text> (); 
		title = GameObject.FindGameObjectWithTag ("gameOverTitle").GetComponent<Text> (); 
		nextLevelButton = GameObject.FindGameObjectWithTag ("nextLevelButton");
		nextLevelButton.SetActive (false);
		nextChapterButton = GameObject.FindGameObjectWithTag ("nextChapterButton");
		nextChapterButton.SetActive (false);
		shareButton = GameObject.FindGameObjectWithTag ("shareButton");
		shareButton.SetActive (false);


		if (ScoreUI.getWinBool ()) {
			title.text = "Level Complete";
			shareButton.SetActive (true);
			if (GameController.levelIndex == 2) {
				nextChapterButton.SetActive (true);
			} else {
				nextLevelButton.SetActive (true);
			}
		} else {
			title.text = "Game Over";
		}

		scoreText.text = "Score: " + score;
		highScoreText.text = "High Score: " + GameController.controller.getHighScore (GameController.controller.getCurrentLevelIndex ());

		ScoreUI.resetScore ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
