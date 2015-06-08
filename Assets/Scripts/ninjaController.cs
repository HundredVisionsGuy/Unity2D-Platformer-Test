using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {
	// Movement
	public float speed;
	public float jump;
	public float moveVelocity = 200f;
	public float maxSpeed = 7f;
	bool grounded = false;
	bool facingRight = true;
	Animator animator = new Animator();
	Rigidbody2D rb;

	void Start() {
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	// Update is called once per frame
	void Update () {
		// Jump
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (grounded) {
				animator.SetBool("isJumping", true);
				rb.velocity = new Vector2(rb.velocity.x, jump);
			}
		}

	}
	void FixedUpdate() {
		// Horizontal Control
		float move = Input.GetAxis ("Horizontal");
		// move left or right if grounded (using AddForce)
		if (grounded) {
			rb.AddForce(Vector2.right * move * moveVelocity);
		}
		if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
			rb.velocity = new Vector2(maxSpeed * move, rb.velocity.y);
		}
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}
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
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
