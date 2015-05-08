using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	// Movement variables
	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false;

	// Update is called once per frame
	void Update () {
		// Jump
		if ( Input.GetKeyDown (KeyCode.Space) || 
		    Input.GetKeyDown (KeyCode.W)) {
			if (grounded) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(
				GetComponent<Rigidbody2D>().velocity.x, jump);
			}
		}
		moveVelocity = 0;

		// Horizontal Movement
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			moveVelocity = -speed; // move left
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			moveVelocity = speed; // move left
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity,
		                                    GetComponent<Rigidbody2D> ().velocity.y);
	}
	// Check to see if grounded or not
	void OnTriggerEnter2D() {
		grounded = true;
	}
	void OnTriggerExit2D() {
		grounded = false;
	}
}
