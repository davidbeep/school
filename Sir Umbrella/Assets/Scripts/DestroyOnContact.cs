using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D c){

		if (c.gameObject.name == "Character") {
			Destroy (c.gameObject);

			// switch to game over screen here
		}
	}
}
