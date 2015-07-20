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
		//if (running) {
			
			score.text = count.ToString ();
			count += 10;
		//}
	}

	public void addScore(int amount ){
		count += amount;
	}

}
