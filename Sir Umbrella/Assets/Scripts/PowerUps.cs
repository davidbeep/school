using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {

	private ControlScript cs;
	public bool windPowerUp; // affects wind force from opening umbrella inside a wind current
	public bool gunPowerUp;
	public bool speedPowerUp; // affects horizontal wind speed
	public float windPowerUpMultiplier;
	public float speedPowerUpMultiplier;

	void Start(){

		cs = (ControlScript)FindObjectOfType (typeof(ControlScript));
	}

	void OnTriggerEnter2D (Collider2D c){

		if (c.gameObject.name == "Character"){

		if (windPowerUp) {
			cs.windForce = cs.windForce * windPowerUpMultiplier;

			Destroy(gameObject);

		}
		if (speedPowerUp){
			cs.horizontalSpeed = cs.horizontalSpeed * speedPowerUpMultiplier;
			
			Destroy(gameObject);
			
		}

	}
	}
}
