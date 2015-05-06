using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	// Movement Variables
	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false;
	
	// Update is called once per frame
	void Update () {
		// Jump
		if (Input.GetKeyDown (KeyCode.Space) ||
			Input.GetKeyDown (KeyCode.W)) {
			if (grounded) {
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(GetComponent<Rigidbody2D>().velocity.x, 
					            jump);
			}
		}
		moveVelocity = 0;

		// Horizontal movement
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.W)){
			moveVelocity -= speed;
		}
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
			moveVelocity += speed;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, 
		                                                     GetComponent<Rigidbody2D>().velocity.y);

	}

	// Check if grounded
	void OnTriggerEnter2D() {
		grounded = true;
	}
	void onTriggerExit2D() {
		grounded = false;
	}

}
