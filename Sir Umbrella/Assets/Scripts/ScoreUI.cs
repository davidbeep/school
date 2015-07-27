using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	public Text score;
	public static int count;
	private static bool win ;

	// Use this for initialization
	void Awake () {
		score = GetComponent<Text> ();
		win = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
			
			score.text = count.ToString ();
			count += 10;

	}

	public static void addScore(int amount ){
		count += amount;
	}
	public static void resetScore(){

		count = 0;
	}
	public static int getScore()
	{
		return count ;
	}
	public static void setWinBool(bool x)
	{
		win = x;
	}
	public static bool getWinBool()
	{
		return win;
	}

}
