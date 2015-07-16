using UnityEngine;
using System.Collections;

public class EnemyHard : MonoBehaviour {

	public float minHorizontalSpeed;
	public float minVerticalSpeed;
	public float maxHorizontalSpeed;
	public float maxVerticalSpeed;
	private float randomX;
	private float randomY;
	private Rigidbody2D rigidBody;
	private float timer = 1; // how long it takes the enemy to switch directions

	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		randomX = Random.Range(minHorizontalSpeed,maxHorizontalSpeed);
		randomY = Random.Range(minVerticalSpeed,maxVerticalSpeed);
	}
	
	void Update () {
		
		timer -= Time.deltaTime;

		if (timer > 0) {
			rigidBody.AddForce (new Vector2 (randomX, randomY)); // apply the force

		}else{
			// randomize x and y forces
			randomX = Random.Range(minHorizontalSpeed,maxHorizontalSpeed);
			randomY = Random.Range(minVerticalSpeed,maxVerticalSpeed);



			timer = 1;
		} 
		
	}
}