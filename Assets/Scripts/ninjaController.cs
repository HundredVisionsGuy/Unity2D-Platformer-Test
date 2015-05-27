using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {
	// Movement
	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false;
	bool facingRight = true;
	protected Animator animator = new Animator();

	void Start() {
		animator = GetComponent<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		// Jump
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (grounded) {
				animator.SetBool("isJumping", true);
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
			}
		}
		moveVelocity = 0;	
		// Horizontal Movement
		if (Input.GetKey (KeyCode.LeftArrow) )
		{
			if (facingRight) Flip();
			moveVelocity = -speed;
			facingRight = false;
		}
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			if (!facingRight) Flip();
			moveVelocity = speed;
			facingRight = true;
		}
		
		// Keep it from continuallay sliding
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}
	// Check if grounded
	void OnTriggerEnter2D()
	{
		grounded = true;
		animator.SetBool ("isJumping", false);
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
