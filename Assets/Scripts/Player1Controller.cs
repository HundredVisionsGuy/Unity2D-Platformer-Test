using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	// Movement Variables
	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false; 
	
	void Update () {
		// Jump
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.Space)) 
		{
			// change the velocity of the rigidbody2D (ONLY if Grounded)
			if (grounded) {
				GetComponent<Rigidbody2D> ().velocity = 
				new Vector2(GetComponent<Rigidbody2D>().velocity.x,
				            jump);
			}
		}
		moveVelocity = 0;

		// Horizontal Movement
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			// move left
			moveVelocity = -speed;
		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			// move right
			moveVelocity = speed;
		}
		// prevent character from sliding
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (
			moveVelocity, 
			GetComponent<Rigidbody2D> ().velocity.y);
	}
	// Check if grounded
	void OnTriggerEnter2D() {
		grounded = true;
	}
	void OnTriggerExit2D() {
		grounded = false;
	}

}
