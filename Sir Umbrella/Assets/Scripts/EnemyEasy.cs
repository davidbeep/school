using UnityEngine;
using System.Collections;

public class EnemyEasy : MonoBehaviour {

	public float horizontalSpeed;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();

		rigidBody.AddForce(new Vector2 (horizontalSpeed,0));// constant horizontal movement
	}
}
