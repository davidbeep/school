using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	public Text score;
	private static int count;

	// Use this for initialization
	void Awake () {
		score = GetComponent<Text> ();
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

}
