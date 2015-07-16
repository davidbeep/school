using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public LayerMask windCurrent;
	public bool hasWind;
	public float windForce;
	private Rigidbody2D rigidBody;
	public float horizontalSpeed;


	void OnTriggerStay2D (Collider2D c){
		hasWind = true;
	}

	void OnTriggerExit2D (Collider2D c){
		hasWind = false;

	}

	// Use this for initialization
	void Start () {
	
		rigidBody = GetComponent<Rigidbody2D> ();
		windCurrent = LayerMask.GetMask ("Wind");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		// might change this to start and remove linear drag to have a constant force from the start
		// but having 0 linear drag might feel weird so it might remain as is.
		rigidBody.AddForce(new Vector2 (horizontalSpeed,0));// constant horizontal movement

		/*if (Input.GetTouch (0).phase == TouchPhase.Began && hasWind) {

			rigidBody.AddForce(new Vector2 (0,windForce));

		} command to be used with phone  */


		// command to test with mouse click
		if (Input.GetMouseButton(0) && hasWind) {
			
			rigidBody.AddForce(new Vector2 (0,windForce));
			
		}
		
	}
}