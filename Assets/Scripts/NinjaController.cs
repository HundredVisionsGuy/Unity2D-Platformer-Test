using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {
	// Movement Variables
	public float speed;
	public float jump;
	protected float moveVelocity;
	float maxSpeed = 10f;
	bool grounded = false;
	bool facingRight = true;
	Animator animator;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Jump
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) {
			if (grounded) {
				rb.velocity =
					new Vector2(rb.velocity.x, 
					            jump);   
				animator.SetBool("isJumping", true);
			}
		}

	}
	void FixedUpdate() {
		moveVelocity = 6f;
		float move = Input.GetAxis ("Horizontal");

		// Add animation clip for run, the view the following video:
		// https://youtu.be/Xnyb2f6Qqzg?t=37m16s

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	
	// Check if grounded
	void OnTriggerEnter2D() {
		grounded = true;
		animator.SetBool("isJumping", false);
	}
	void OnTriggerExit2D() {
		grounded = false;
	}
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
