using UnityEngine;
using System.Collections;
using UnityEngine.UI ;

public class gameOver : MonoBehaviour {

	private int score ;
	private Text title ;
	private Text scoreText ;
	private Text highScoreText ;

	// Use this for initialization
	void Start () {
		score = ScoreUI.getScore() ;
		scoreText = GameObject.FindGameObjectWithTag("scoreText").GetComponent<Text>() ; 
		highScoreText = GameObject.FindGameObjectWithTag("highScoreText").GetComponent<Text>() ; 
		title = GameObject.FindGameObjectWithTag("gameOverTitle").GetComponent<Text>() ; 

		if (score >= 8500 && ScoreUI.getWinBool())
		{
			title.text = "Level Complete" ;
		} 
		else 
		{
			title.text = "Game Over";
		}

		scoreText.text = "Score: " + score;
		highScoreText.text = "High Score: " + GameController.controller.getHighScore (GameController.controller.getCurrentLevelIndex());

		ScoreUI.resetScore();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
