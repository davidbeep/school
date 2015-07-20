using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	private ControlScript cs;
	public bool windPowerUp; // affects wind force from opening umbrella inside a wind current
	public bool gunPowerUp;
	public bool scorePowerUp;
	public bool speedPowerUp;// affects horizontal wind speed
	public float windPowerUpMultiplier;
	public float speedPowerUpMultiplier;
	public int scorePowerUpAmount;

	private ScoreUI scoreCount = new ScoreUI ();

	void Start(){

		cs = (ControlScript)FindObjectOfType (typeof(ControlScript));
	}

	void OnTriggerEnter2D (Collider2D c){

		if (c.gameObject.name == "Character"){

			scoreCount.addScore(5000);

		if (windPowerUp) {
			cs.windForce = cs.windForce * windPowerUpMultiplier;

			Destroy(gameObject);

		}
		if (speedPowerUp){
			cs.horizontalSpeed = cs.horizontalSpeed * speedPowerUpMultiplier;
			
			Destroy(gameObject);
			
		}
		if(scorePowerUp){
			scoreCount.addScore(scorePowerUpAmount);

		    Destroy(gameObject);
		}

		}
	}
}
