using UnityEngine;
using System.Collections;

public class charControl : MonoBehaviour {

	private Rigidbody2D rigidBody;
	private float windVertical, windHorizontal, constantHorizontal ;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		windVertical = 16f;
		windHorizontal = 0.8f;
		constantHorizontal = 0.5f;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
		// might change this to start and remove linear drag to have a constant force from the start
		// but having 0 linear drag might feel weird so it might remain as is.

		
		/*if (Input.GetTouch (0).phase == TouchPhase.Began && hasWind) {

			rigidBody.AddForce(new Vector2 (0,windForce));

		} command to be used with phone  */
		
		
		// command to test with mouse click
		if (Input.GetMouseButton (0)) {
			
			rigidBody.AddForce (new Vector2 (windHorizontal, windVertical));
			
		} 
		else
		{
			rigidBody.AddForce(new Vector2 (constantHorizontal,0f));// constant horizontal movement
		}
		
	}
}
