﻿using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour
{

	public LayerMask windCurrent;
	public static bool hasWind = true; // remove once wind is implemented
	public float windForce;
	private Rigidbody2D rigidBody;
	public float horizontalSpeed;
	private bool initialPause;
	private GameObject startText;
	private float resumeDelay = 0.3f;
	private float horizontalVelocity;


	void OnTriggerStay2D (Collider2D c)
	{
		//hasWind = true;
	}

	void OnTriggerExit2D (Collider2D c)
	{
		//hasWind = false;

	}

	// Use this for initialization
	void Start ()
	{

		Time.timeScale = 0.0f; //starts paused, tap screen to begin game
		initialPause = true;
		rigidBody = GetComponent<Rigidbody2D> ();
		windCurrent = LayerMask.GetMask ("Wind");
		startText = GameObject.Find ("StartText");
	}
	
	// Update is called once per frame
	void Update ()
	{

		hasWind = true; // remove once wind is implemented
		
		if (Time.timeScale == 0.0f && Input.GetMouseButton (0)) {

			resumeDelay = Time.deltaTime; // to add a small delay on resume in order to make it feel more fluid
			if (resumeDelay <= 0) {
				if (initialPause) {
					Destroy (startText);

				}
				Time.timeScale = 1.0f; // begin or resume game
			}
			
		}

	}

	void FixedUpdate ()
	{
	
		// might change this to start and remove linear drag to have a constant force from the start
		// but having 0 linear drag might feel weird so it might remain as is.
		rigidBody.AddForce (new Vector2 (horizontalSpeed, 0));// constant horizontal movement

		/*if (Input.GetTouch (0).phase == TouchPhase.Began && hasWind) {

			rigidBody.AddForce(new Vector2 (0,windForce));

		} command to be used with phone  */


		// command to test with mouse click
		// third condition makes sure player doesn't go above the top of the screen
		if (Input.GetMouseButton (0) && hasWind && gameObject.transform.position.y < 4.24) {
			
			rigidBody.AddForce (new Vector2 (0, windForce));
			
		}
		// this is added to stop player's vertical velocity when they hit the top of the screen
		if (gameObject.transform.position.y > 4.25) {
			horizontalVelocity = rigidBody.velocity.x;
			// stop player from going above the ceiling of the level
			rigidBody.velocity = new Vector2 (horizontalVelocity, 0);
	
		}
	}
}
