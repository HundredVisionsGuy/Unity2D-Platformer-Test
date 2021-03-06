﻿using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

	// Movement
	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false;
	bool facingRight = true;

	// Update is called once per frame
	void Update () 
	{
		// Jump
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			if (grounded) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
			}
		}
		moveVelocity = 0;	
		// Horizontal Movement
		if (Input.GetKey (KeyCode.A) )
	    {
			if (facingRight) Flip();
			moveVelocity = -speed;
			facingRight = false;
		}
		if (Input.GetKey (KeyCode.D)) 
		{
			if (!facingRight) Flip();
			moveVelocity = speed;
			facingRight = true;
		}

		// Keep it from continually sliding

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}

	// Check if grounded
	void OnTriggerEnter2D()
	{
		grounded = true;
	}
	void OnTriggerExit2D()
	{
		grounded = false;
	}
	void Flip() 
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}