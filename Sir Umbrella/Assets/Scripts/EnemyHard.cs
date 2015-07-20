using UnityEngine;
using System.Collections;

public class EnemyHard : MonoBehaviour {

	public float minHorizontalSpeed;
	public float minVerticalSpeed;
	public float maxHorizontalSpeed;
	public float maxVerticalSpeed;
	private float randomX,oldX;
	private float randomY,oldY;
	private Rigidbody2D rigidBody;
	private float timer; // how long it takes the enemy to switch directions

	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		randomX = Random.Range(minHorizontalSpeed,maxHorizontalSpeed);
		randomY = Random.Range(minVerticalSpeed,maxVerticalSpeed);
	}
	
	void Update () {
		
		timer -= Time.deltaTime;

		if (timer <= 0) {

		

			// randomize x and y forces
			oldX = randomX;
			oldY = randomY;
			randomX = Random.Range(minHorizontalSpeed,maxHorizontalSpeed);
			randomY = Random.Range(minVerticalSpeed,maxVerticalSpeed);
			if (Mathf.Abs(oldX + randomX) > (maxHorizontalSpeed/2) || oldX + randomX > Mathf.Abs(minHorizontalSpeed/2)){
				randomX = -randomX;
			}
			if (Mathf.Abs(oldY + randomY) > (maxVerticalSpeed/2) || oldY + randomY > Mathf.Abs(minVerticalSpeed/2)){
				randomY = -randomY;
			}

			rigidBody.AddForce (new Vector2 (randomX, randomY)); // apply the force

			timer = 2;
		} 
		
	}
}

/* simpler implementation, tends to go off screen too quickly, new implementation lowers that chance
 * if(timer > 0) {
			rigidBody.AddForce (new Vector2 (randomX, randomY)); // apply the force

		}else{
			// randomize x and y forces

			randomX = Random.Range(minHorizontalSpeed,maxHorizontalSpeed);
			randomY = Random.Range(minVerticalSpeed,maxVerticalSpeed);



			timer = 1;
		} */