using UnityEngine;
using System.Collections;

public class EnemyMedium : MonoBehaviour {
	
	public float horizontalSpeed;
	public float verticalSpeed;
	private Rigidbody2D rigidBody;
	private float timer = 1; // how many seconds it takes to reverse the direction of the vertical force
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.AddForce(new Vector2 (horizontalSpeed,0));// constant horizontal movement
	}

	void Update () {

		timer -= Time.deltaTime;

		if (timer > 0) {
			rigidBody.AddForce (new Vector2 (0, verticalSpeed)); // apply the force
		} else {
			// reverse the direction of the force
			verticalSpeed = -verticalSpeed;
			timer = 2;
		}

	}
}
