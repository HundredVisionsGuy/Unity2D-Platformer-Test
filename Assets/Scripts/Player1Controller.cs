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
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			// change the velocity of the rigidbody2D
			GetComponent<Rigidbody2D> ().velocity = 
				new Vector2(GetComponent<Rigidbody2D>().velocity.x,
				            jump);
		}
		moveVelocity = 0;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (
			moveVelocity, 
			GetComponent<Rigidbody2D> ().velocity.y);

	}
}
