using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {
	// Movement Variables
	public float speed;
	public float jump;
	float moveVelocity = 200f;
	float maxSpeed = 7f;
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
		float move = Input.GetAxis ("Horizontal");

		// Add animation clip for run, the view the following video:
		// https://youtu.be/Xnyb2f6Qqzg?t=37m16s

		// rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);
		if (grounded) {
			rb.AddForce (Vector2.right * moveVelocity * move);
			if (move != 0) {
				animator.SetBool ("isRunning", true);
			}
			else {
				animator.SetBool("isRunning", false);
			}
		}
		if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
			rb.velocity=new Vector2(maxSpeed*move, rb.velocity.y);
		} 
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}
	
	// Check if grounded
	void OnTriggerEnter2D() {
		grounded = true;
		animator.SetBool("isJumping", false);
		animator.SetBool ("isGrounded", true);
	}
	void OnTriggerExit2D() {
		grounded = false;
		animator.SetBool ("isGrounded", false);
		if (rb.velocity.y > 0) {
			animator.SetBool("isJumping", true);
		}
	}
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
