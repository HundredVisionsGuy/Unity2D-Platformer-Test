using UnityEngine;
using System.Collections;

public class NinjaController : MonoBehaviour {
	// Movement Variables
	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false;
	Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		// Jump
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (grounded) {
				animator.SetBool("isJumping", true);
				GetComponent<Rigidbody2D>().velocity =
					new Vector2(GetComponent<Rigidbody2D>().velocity.x, 
					            jump);
			}
		}
		moveVelocity = 0;
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, 
		                                                     GetComponent<Rigidbody2D>().velocity.y);
	}
	
	// Check if grounded
	void OnTriggerEnter2D() {
		grounded = true;
		animator.SetBool("isJumping", false);
	}
	void OnTriggerExit2D() {
		grounded = false;
	}
	
}
